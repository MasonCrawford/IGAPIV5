using System.Net;
using Akka.Util.Internal;
using Data.Dto;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory.Interfaces;
using IgClient.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradingService.Interfaces;

namespace DataFactory;

public class TradingChartDataService : ITradingChartDataService
{
    private readonly IIgRestApiClient _client;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ITradingChartDataService> _logger;
    private readonly ITradingChartRepository _tradingChartRepository;
    private readonly ITradingChartService _tradingChartService;
    private readonly IEntityRepository<PricesEntity> _pricesRepository;

    public TradingChartDataService(
        ILogger<ITradingChartDataService> logger,
        IIgRestApiClient client,
        IServiceScopeFactory scopeFactory,
        ITradingChartService tradingChartService,
        ITradingChartRepository tradingChartRepository,
        IEntityRepository<PricesEntity> pricesRepository)
    {
        _logger = logger;
        _client = client;
        _scopeFactory = scopeFactory;
        _tradingChartService = tradingChartService;
        _tradingChartRepository = tradingChartRepository;
        _pricesRepository = pricesRepository;
    }

    public async Task<TradingChartDto> GetFullTradingChart(string tradingTargetChartCode)
    {
        // var tradingChart = _context.TradingChart.AsNoTracking().Where(chart => chart.ChartCode == tradingTargetChartCode)
        //     .Include(chart => chart.Prices).AsNoTracking().FirstOrDefault();
        // if (tradingChart == null) return null;
        //
        // var prices = new List<PricesEntity>();
        // foreach (var price in tradingChart.Prices.OrderByDescending(x => x.CreatedOnUtc).Take(200))
        //     prices.Add(_context.Prices.AsNoTracking()
        //         .Where(p => p.Id == price.Id)
        //         .Include(p1 => p1.ClosePrice).AsNoTracking()
        //         .Include(p2 => p2.OpenPrice).AsNoTracking()
        //         .Include(p3 => p3.LowPrice).AsNoTracking()
        //         .Include(p4 => p4.HighPrice).AsNoTracking()
        //         .FirstOrDefault());
        //
        // tradingChart.Prices = prices;
        //
        // if (prices.Count > 199)
        //     tradingChart.Prices = prices;
        // else
        //     tradingChart.Prices = await SeedTradingChart(tradingTargetChartCode);
        // _tradingChartRepository.Update(tradingChart);
        // return Map(tradingChart);

        var tradingChart =  _tradingChartRepository.Get(entity => entity.ChartCode == tradingTargetChartCode, null,
            entity => entity.Prices).FirstOrDefault();
        
        if (tradingChart == null) return null;

        tradingChart.Prices = tradingChart.Prices?.Count < 200
            ? await SeedTradingChart(tradingTargetChartCode)
            : LoadSavedPrices(tradingChart);

        _tradingChartRepository.Update(tradingChart);

        return Map(tradingChart);

    }

    public IEnumerable<string?> ChartCodes()
    {
        return _tradingChartRepository.Get().Select(x => x.ChartCode).ToList();
    }

    private List<PricesEntity> LoadSavedPrices(TradingChartEntity tradingChart)
    {
        var results = new List<PricesEntity>();
        
        tradingChart!.Prices?.OrderByDescending(x => x.CreatedOnUtc)
            .Take(200)
            .ForEach(p => results.Add(_pricesRepository.Get(entity => entity.Id == p.Id,
                    null,
                    entity => entity.ClosePrice,
                    entity => entity.OpenPrice,
                    entity => entity.HighPrice,
                    entity => entity.LowPrice)
                .FirstOrDefault()));
        return results;
    }

    public async Task RemoveOldPrices(int dayToKeep = -1)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var oldDate = DateTime.Now.AddDays(dayToKeep);
        var oldPrices = context.Prices.Where(prices => prices.CreatedOnUtc < oldDate)
            .Include(p1 => p1.ClosePrice)
            .Include(p2 => p2.OpenPrice)
            .Include(p3 => p3.LowPrice)
            .Include(p4 => p4.HighPrice)
            .ToList();

        foreach (var oldPrice in oldPrices)
        {
            context.Price.RemoveRange(oldPrice.ClosePrice);
            context.Price.RemoveRange(oldPrice.OpenPrice);
            context.Price.RemoveRange(oldPrice.HighPrice);
            context.Price.RemoveRange(oldPrice.LowPrice);
            context.Prices.RemoveRange(oldPrice);
        }

        await context.SaveChangesAsync();
        _logger.LogWarning($"Removed {oldPrices.Count} prices");
    }

    public void Update(TradingChartDto tradingChart)
    {
        _tradingChartRepository.Update(Map(tradingChart));
    }

    public TradingChartDto Map(TradingChartEntity entity)
    {
        return new TradingChartDto
        {
            Id = entity.Id,
            CreatedOnUtc = entity.CreatedOnUtc,
            LastModifiedOnUtc = entity.LastModifiedOnUtc,
            Prices = MapPrices(entity.Prices),
            ChartCode = entity.ChartCode
        };
    }

    public TradingChartEntity Map(TradingChartDto dto)
    {
        return new TradingChartEntity
        {
            Id = dto.Id??new Guid(),
            CreatedOnUtc = dto.CreatedOnUtc,
            LastModifiedOnUtc = dto.LastModifiedOnUtc,
            Prices = MapPrices(dto.Prices),
            ChartCode = dto.ChartCode
        };
    }

    /// <summary>
    ///     seeds the values of a trading chart with the 200 most recent values from the rest api
    /// </summary>
    /// <param name="tradingTargetChartCode"></param>
    private async Task<List<PricesEntity>> SeedTradingChart(string tradingTargetChartCode)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var tradingTarget = context.TradingTargets.FirstOrDefault(x => x.ChartCode == tradingTargetChartCode);
        var epic = tradingTarget?.Epic;
        if (string.IsNullOrWhiteSpace(epic))
        {
            _logger.LogError("could not find a epic for the given chart code");
            return null;
        }

        var priceResponse = await _client.priceSearchByNumV2(epic, "MINUTE_5", "200");
        if (priceResponse.StatusCode == HttpStatusCode.OK)
        {
            var priceListHistory = priceResponse.Response.prices;
            var prices = priceListHistory.Select(priceSnapshot => new PricesEntity
            {
                HighPrice = new PriceEntity
                {
                    Bid = priceSnapshot.highPrice.bid, Ask = priceSnapshot.highPrice.ask,
                    LastTraded = priceSnapshot.highPrice.lastTraded
                },
                LowPrice = new PriceEntity
                {
                    Bid = priceSnapshot.lowPrice.bid, Ask = priceSnapshot.lowPrice.ask,
                    LastTraded = priceSnapshot.lowPrice.lastTraded
                },
                OpenPrice = new PriceEntity
                {
                    Bid = priceSnapshot.openPrice.bid, Ask = priceSnapshot.openPrice.ask,
                    LastTraded = priceSnapshot.openPrice.lastTraded
                },
                ClosePrice = new PriceEntity
                {
                    Bid = priceSnapshot.closePrice.bid, Ask = priceSnapshot.closePrice.ask,
                    LastTraded = priceSnapshot.closePrice.lastTraded
                }
            }).ToList();
            var pl = new List<PricesEntity>();
            prices.ForEach(p =>
            {
                pl.Insert(0, p);
                pl.First().MovingAverage =
                    _tradingChartService.CalculateMovingAverage(MapPrices(pl), tradingTarget.MovingAverageLength ?? 0);
            });
            return pl;
        }

        return null;
    }

    public List<PricesDto> MapPrices(List<PricesEntity> entities)
    {
        return entities.Select(x => new PricesDto
        {
            Id = x.Id,
            ClosePrice = new PriceDto
            {
                Id = x.ClosePrice?.Id??new Guid(),
                Ask = x.ClosePrice?.Ask,
                Bid = x.ClosePrice?.Bid,
                LastTraded = x.ClosePrice?.LastTraded
            },
            HighPrice = new PriceDto
            {
                Id = x.HighPrice?.Id??new Guid(),
                Ask = x.HighPrice?.Ask,
                Bid = x.HighPrice?.Bid,
                LastTraded = x.HighPrice?.LastTraded
            },
            LowPrice = new PriceDto
            {
                Id = x.LowPrice?.Id??new Guid(),
                Ask = x.LowPrice?.Ask,
                Bid = x.LowPrice?.Bid,
                LastTraded = x.LowPrice?.LastTraded
            },
            OpenPrice = new PriceDto
            {
                Id = x.OpenPrice?.Id??new Guid(),
                Ask = x.OpenPrice?.Ask,
                Bid = x.OpenPrice?.Bid,
                LastTraded = x.OpenPrice?.LastTraded
            },
            MovingAverage = x.MovingAverage
        }).ToList();
    }

    public List<PricesEntity> MapPrices(List<PricesDto> entities)
    {
        return entities.Select(x => new PricesEntity
        {
            Id = x.Id??new Guid(),
            ClosePrice = new PriceEntity
            {
                Id = x.ClosePrice.Id??new Guid(),
                Ask = x.ClosePrice.Ask,
                Bid = x.ClosePrice.Bid,
                LastTraded = x.ClosePrice.LastTraded
            },
            HighPrice = new PriceEntity
            {
                Id = x.HighPrice.Id??new Guid(),
                Ask = x.HighPrice.Ask,
                Bid = x.HighPrice.Bid,
                LastTraded = x.HighPrice.LastTraded
            },
            LowPrice = new PriceEntity
            {
                Id = x.LowPrice.Id??new Guid(),
                Ask = x.LowPrice.Ask,
                Bid = x.LowPrice.Bid,
                LastTraded = x.LowPrice.LastTraded
            },
            OpenPrice = new PriceEntity
            {
                Id = x.OpenPrice.Id??new Guid(),
                Ask = x.OpenPrice.Ask,
                Bid = x.OpenPrice.Bid,
                LastTraded = x.OpenPrice.LastTraded
            },
            MovingAverage = x.MovingAverage
        }).ToList();
    }
}
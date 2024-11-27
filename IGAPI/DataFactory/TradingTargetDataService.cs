using System.Net;
using Common;
using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory.Interfaces;
using IgClient;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.confirms;
using IgClient.Model.dto.endpoint.positions.create.otc.v1;
using IgClient.Model.dto.endpoint.positions.create.otc.v2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ITrailingStopService = DataFactory.Interfaces.ITrailingStopService;

namespace DataFactory;

public class TradingTargetDataService : ITradingTargetDataService
{
    private readonly IIgRestApiClient _client;
    private readonly ILogger<ITradingTargetDataService> _logger;
    private readonly IOrderDataService _orderDataService;
    private readonly IEntityRepository<TradingTargetEntity> _repository;
    private readonly IEntityRepository<DepositBandEntity> _depositBandRepository;

    public TradingTargetDataService(IOrderDataService orderDataService,
        IIgRestApiClient client, IEntityRepository<TradingTargetEntity> repository,IEntityRepository<DepositBandEntity> depositBandRepository,
        ILogger<ITradingTargetDataService> logger)
    {
        _orderDataService = orderDataService;
        _client = client;
        _repository = repository;
        _depositBandRepository = depositBandRepository;
        _logger = logger;
    }

    public List<TradingTargetsDto> Get()
    {
        _logger.LogInformation($"Getting all TradingTargets");
        return _repository
            .Get(targets => targets.Status != Enums.status.Closed, null, entity => entity.MarginDepositBands,
                entity => entity.Orders).Select(x => Map(x)).ToList();
    }

    public TradingTargetsDto? GetFullTradingTargetById(Guid? id)
    {
        _logger.LogInformation($"Getting TradingTarget");

        var tradingTarget = _repository.Get(targets => targets.Id == id, null, entity => entity.MarginDepositBands,
            entity => entity.Orders).FirstOrDefault();
        if (tradingTarget == null)
        {
            _logger.LogError($"No TradingTarget found for given ID: {id}");
            return null;
        }
        
        _logger.LogInformation($"Returning TradingTarget {tradingTarget.Name}");
        
        return Map(tradingTarget);
    }

   

    /// <summary>
    ///     seeds values that can change from time to time by getting the Market results for each tradingTarget
    /// </summary>
    public async Task SeedMarketValues()
    {
        _logger.LogInformation("Starting to Seed Market Values ");
        foreach (var tradingTarget in _repository.Get(targets => targets.Status != Enums.status.Closed, null,
                     entity => entity.MarginDepositBands, entity => entity.Orders))
        {
            var marketResponse = await _client.marketDetails(tradingTarget.Epic);
            if (marketResponse.StatusCode == HttpStatusCode.OK)
            {
                _logger.LogInformation($"Seeding market values for {tradingTarget.Epic}");

                tradingTarget.Name = marketResponse.Response.instrument.name;
                tradingTarget.Expiry = marketResponse.Response.instrument.expiry;
                tradingTarget.ScalingFactor = marketResponse.Response.snapshot.scalingFactor;

                foreach (DepositBandEntity depositBand in tradingTarget.MarginDepositBands)
                {
                    _depositBandRepository.Delete(depositBand);
                }
                
                tradingTarget.MarginDepositBands = new List<DepositBandEntity>();
                foreach (var depositBand in marketResponse.Response.instrument.marginDepositBands)
                    tradingTarget.MarginDepositBands.Add(new DepositBandEntity
                    {
                        Margin = depositBand.margin / 10,
                        Max = depositBand.max * 1000,
                        Min = depositBand.min * 1000
                    });
                _repository.Update(tradingTarget);
            }
            else
            {
                _logger.LogError($"failed to seed market values for {tradingTarget.Epic}");
            }
        }
    }

    private async Task GetOrderProfit(Guid? id)
    {
        var tradingTarget = Map(_repository.Get(entity => entity.Id == id, null, entity => entity.Orders, entity => entity.MarginDepositBands ).FirstOrDefault());
        _logger.LogInformation($"tradingTarget {tradingTarget.Name} has {tradingTarget.Orders.Count} orders");
        if (tradingTarget.Orders.Any() && tradingTarget.Orders.Last().Profit == null)
        {
            var oderHistoryResponse =
                await _client.lastTransactionPeriod("ALL_DEAL", new TimeSpan(0, 11, 0).TotalSeconds.ToString());
            var oderHistory = oderHistoryResponse.StatusCode == HttpStatusCode.OK
                ? oderHistoryResponse.Response
                : null;
            
            if (oderHistory != null)
            {
                _logger.LogInformation($"{oderHistory.transactions.Count} orders found in the last {new TimeSpan(1, 0, 0).TotalSeconds} seconds");
                if (oderHistory.transactions.Count > 0)
                {
                    _logger.LogInformation($"Attempting to match transactions with orders");
                    
                    var transactions = oderHistory.transactions.Where(x =>
                        x.instrumentName.Contains(tradingTarget.Name) && !tradingTarget.Orders
                            .Select(x => x.TransactionReference)
                            .Contains(x.reference));
                    
                    if (transactions.Any())
                    {
                        _logger.LogInformation($"{transactions.Count()} Matches Found");
                        foreach (var transaction in transactions)
                        {

                            OrderDto? order = null;

                            foreach (var orders in tradingTarget.Orders)
                            {
                                order = string.IsNullOrEmpty(orders.TransactionReference)
                                    ? orders
                                    : null;
                            }

                            if (order != null)
                            {
                                _logger.LogInformation(
                                    $"Transaction {transaction.reference} Matched with order {order.Id}");
                                order.TransactionReference = transaction.reference;
                                try
                                {
                                    var formattedProfit = transaction.profitAndLoss.Remove(0, 2);
                                    order.Profit = Decimal.Parse(formattedProfit);
                                }
                                catch (FormatException e)
                                {
                                    _logger.LogError(
                                        $"Unable to parse '{transaction.profitAndLoss}'. message: {e.Message}");
                                }

                                if (order.Profit != null)
                                {

                                    tradingTarget.Profit +=
                                        order.Profit.Value;
                                    tradingTarget.TradingLevel +=
                                        order.Profit.Value > 0 ? 1 : -1;
                                    _repository.Update(Map(tradingTarget));
                                    _orderDataService.Update(order);
                                }

                                _logger.LogInformation(
                                    $"Order {order.OrderId} was closed with a profit/loss of {transaction.profitAndLoss}");
                            }
                            else
                            {
                                _logger.LogWarning("no orders made by the app match the transaction that was found");
                            }
                        }
                    }
                    else
                    {
                        _logger.LogWarning("No Match was found"); 
                    }
                }
                else
                {
                    _logger.LogInformation("There are no recent closed transactions"); 
                }
            }
            else
            {
                _logger.LogInformation("There are no recent closed transactions"); 
            }
                
        }
    }
    
    public async Task<Enums.status> UpdatePosition(Guid? id)
    {
        await GetOrderProfit(id);
        var tradingTarget = GetFullTradingTargetById(id);
        if (tradingTarget == null)
        {
            _logger.LogError($"Can not find a trading target for provided ID: {id}");
            return Enums.status.Closed;
        }
        var positions = await _client.getOTCOpenPositionsV2();
        if (positions.StatusCode == HttpStatusCode.OK)
        {
            var position = positions.Response.positions.FirstOrDefault(x => x?.market.epic == tradingTarget.Epic);
            tradingTarget.Status = position != null ? Enums.status.Hold : Enums.status.Active;
            _logger.LogInformation($"Current Market.status is: {tradingTarget.Status}");
            if (position != null)  _logger.LogInformation($"A {position.position.direction} position is open ");
            _repository.Update(Map(tradingTarget));
        }

        return tradingTarget.Status;
    }
    
    public async Task<string?> PlaceOrder(TradingTargetsDto tradingTarget, Enums.orderAction orderAction)
    {
        _logger.LogInformation($"Placeing order for {tradingTarget.Name}");
        var order = _orderDataService.CreateOrder(tradingTarget);
        var direction = orderAction == Enums.orderAction.BUY ? "buy" : "Sell";
        
        _logger.LogInformation($"created {direction} order: ContractSize:{order.ContractSize}, TargetAmount:{order.TargetAmount}, RiskAmount:{order.RiskAmount}");

        var request = new CreatePositionRequest
        {
            currencyCode = "USD",
            epic = tradingTarget.Epic,
            expiry = tradingTarget.Expiry,
            direction = direction.ToUpper(),
            size = order.ContractSize,
            forceOpen = true,
            guaranteedStop = false,
            trailingStop = false,
            orderType = "MARKET",
            limitDistance = order.TargetAmount / order.ContractSize,
            stopDistance = order.RiskAmount / order.ContractSize
        };
        
        var positionResponse = await _client.createPositionV2(request);
        if (positionResponse.StatusCode == HttpStatusCode.OK)
        {
            var confirm = await _client.retrieveConfirm(positionResponse.Response.dealReference);
            
            if (confirm.StatusCode == HttpStatusCode.OK)
            {
                if (confirm.Response.dealStatus != "REJECTED")
                {
                    order.OrderId = confirm.Response.dealId;
                    order.LastKnowPrice = confirm.Response.level;
                    order.Accepted = confirm.Response.dealStatus.ToUpper() == "ACCEPTED";
                    order.OrderAction = orderAction;
                    _logger.LogWarning(
                        $"order {confirm.Response.dealId} was {confirm.Response.dealStatus.ToLower()}, reason: {confirm.Response.reason} ");
                    tradingTarget.Orders.Add(order);
                    _repository.Update(Map(tradingTarget));
                }
                else
                {
                    _logger.LogError($"The order was not accepted, reason: {confirm.Response.reason}");
                }
                return confirm.Response.dealId;
            }
        }

        _logger.LogError("The order was not placed, look at the logs");
        return null;
    }
    
    public TradingTargetsDto Map(TradingTargetEntity entity)
    {
        return new TradingTargetsDto
        {
            Id = entity.Id,
            CreatedOnUtc = entity.CreatedOnUtc,
            LastModifiedOnUtc = entity.LastModifiedOnUtc,
            Epic = entity.Epic ?? "",
            Expiry = entity.Expiry ?? "",
            Method = entity.Method,
            Name = entity.Name ?? "",
            Orders = entity.Orders.Count > 0
                ? entity.Orders.Select(x => _orderDataService.Map(x)).ToList()
                : new List<OrderDto>(),
            Profit = entity.Profit ?? 0,
            ScalingFactor = entity.ScalingFactor ?? 0,
            Status = entity.Status,
            ChartCode = entity.ChartCode ?? "",
            CurrencyCode = entity.CurrencyCode ?? "",
            InitialDeposit = entity.InitialDeposit ?? 0,
            MarginDepositBands = entity.MarginDepositBands.Select(x =>
                new DepositBandDto
                {
                    Id = x.Id,
                    Currency = x.Currency ?? "",
                    Margin = x.Margin,
                    Max = x.Max ?? 0,
                    Min = x.Min ?? 0
                }).ToList(),
            RiskPercent = entity.RiskPercent ?? 0,
            TargetPercent = entity.TargetPercent ?? 0,
            TradingLevel = entity.TradingLevel ?? 0,
            MovingAverageLength = entity.MovingAverageLength ?? 0
        };
    }

    public TradingTargetEntity Map(TradingTargetsDto dto)
    {
        return new TradingTargetEntity
        {
            Id = dto.Id??new Guid(),
            CreatedOnUtc = dto.CreatedOnUtc,
            LastModifiedOnUtc = dto.LastModifiedOnUtc,
            Epic = dto.Epic,
            Expiry = dto.Expiry,
            Method = dto.Method,
            Name = dto.Name,
            Orders = dto.Orders.Select(x =>
                _orderDataService.Map(x)).ToList(),
            Profit = dto.Profit,
            ScalingFactor = dto.ScalingFactor,
            Status = dto.Status,
            ChartCode = dto.ChartCode,
            CurrencyCode = dto.CurrencyCode,
            InitialDeposit = dto.InitialDeposit,
            MarginDepositBands = dto.MarginDepositBands.Select(x =>
                new DepositBandEntity
                {
                    Id = x.Id??new Guid(),
                    Currency = x.Currency,
                    Margin = x.Margin,
                    Max = x.Max,
                    Min = x.Min
                }).ToList(),
            RiskPercent = dto.RiskPercent,
            TargetPercent = dto.TargetPercent,
            TradingLevel = dto.TradingLevel,
            MovingAverageLength = dto.MovingAverageLength
        };
    }
}
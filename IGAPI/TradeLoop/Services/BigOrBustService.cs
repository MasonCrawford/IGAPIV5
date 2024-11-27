using Common;
using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;
using TradingService.Interfaces;

namespace TradeLoop.Services;

public class BigOrBustService: IBigOrBustService
{
    private readonly ILogger<IBigOrBustService> _logger;
    private readonly ITradingChartDataService _tradingChartDataService;
    private readonly ITradingTargetDataService _tradingTargetDataService;
    private readonly IServiceScopeFactory _scopeFactory;

    private readonly ITradingChartService _tradingChartService;
    public BigOrBustService(ILogger<IBigOrBustService> logger,
        ITradingChartDataService tradingChartDataService,
        ITradingTargetDataService tradingTargetDataService,
        ITradingChartService tradingChartService,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _tradingChartDataService = tradingChartDataService;
        _tradingTargetDataService = tradingTargetDataService;
        _tradingChartService = tradingChartService;
        _scopeFactory = scopeFactory;
    }

    public async Task<int> Start(Guid? tradingTargetId)
    {
        using var scope = _scopeFactory.CreateScope();
        var trailingStopService = scope.ServiceProvider.GetRequiredService<ITrailingStopService>();
        
        var tradingTarget = _tradingTargetDataService.GetFullTradingTargetById(tradingTargetId);
        _logger.LogInformation($"Starting BigOrBust Method for {tradingTarget.Name}");

        var status = await _tradingTargetDataService.UpdatePosition(tradingTarget.Id);
        
        if (status == Enums.status.Active)
        {
            var tradingChart = await _tradingChartDataService.GetFullTradingChart(tradingTarget?.ChartCode);
                
            if (tradingChart != null)
            {
                if (IsBuy(tradingChart))
                {
                    trailingStopService.SubscribeTrailingStop(tradingTarget,
                        await _tradingTargetDataService.PlaceOrder(tradingTarget, Enums.orderAction.BUY));
                }
                else if (IsSell(tradingChart))
                {
                    trailingStopService.SubscribeTrailingStop(tradingTarget,
                        await _tradingTargetDataService.PlaceOrder(tradingTarget, Enums.orderAction.SELL));
                }
            }
            else
            {
                _logger.LogError("there was an error getting the required chart details ");
                return -1;
            }
        }
        else
        {
            _logger.LogInformation("An Order is open, Saving price only");
        }

        return 0;
    }
    
    public bool IsBuy(TradingChartDto chartEntity)
    {
        _logger.LogInformation("Starting IsBuy validation");
        return _tradingChartService.IsMovingUp(chartEntity);
    }

    public bool IsSell(TradingChartDto chartEntity)
    {
        _logger.LogInformation("Starting IsSell validation");
        return _tradingChartService.IsMovingDown(chartEntity);
    }
    
    
}
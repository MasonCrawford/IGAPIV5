using Common;
using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;
using TradingService.Interfaces;

namespace TradeLoop.Services;

public class ThreeTickSnipeService : IThreeTickSnipeService
{
    private readonly ILogger<ThreeTickSnipeService> _logger;
    private readonly IOrderDataService _orderDataService;
    private readonly ITradingChartDataService _tradingChartDataService;
    private readonly ITradingTargetDataService _tradingTargetDataService;
    private readonly ITradingChartService _tradingChartService;

    public ThreeTickSnipeService(ITradingChartDataService tradingChartDataService,ITradingTargetDataService tradingTargetDataService,
        ITradingChartService tradingChartService, ILogger<ThreeTickSnipeService> logger,
        IOrderDataService orderDataService)
    {
        _tradingChartDataService = tradingChartDataService;
        _tradingTargetDataService = tradingTargetDataService;
        _tradingChartService = tradingChartService;
        _logger = logger;
        _orderDataService = orderDataService;
    }
    
    public async Task<int> Start(Guid? tradingTargetId)
    {
        var tradingTarget = _tradingTargetDataService.GetFullTradingTargetById(tradingTargetId);
        _logger.LogInformation($"Starting TreeTickSnipe Method for {tradingTarget.Name}");
        
        var status = await _tradingTargetDataService.UpdatePosition(tradingTarget.Id);
        if (status == Enums.status.Active)
        {
            var tradingChart = await _tradingChartDataService.GetFullTradingChart(tradingTarget?.ChartCode);
                
            if (tradingChart != null)
            {
                if (IsBuy(tradingChart))
                {
                   await _tradingTargetDataService.PlaceOrder(tradingTarget, Enums.orderAction.BUY);
                }
                else if (IsSell(tradingChart))
                {
                   await _tradingTargetDataService.PlaceOrder(tradingTarget, Enums.orderAction.SELL);
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
        if (!_tradingChartService.IsMovingDown(chartEntity)) return false;
        if (!_tradingChartService.IsEngulfing(chartEntity)) return false;
        var result = chartEntity.Prices[0].IsRed &&
                     !chartEntity.Prices[1].IsRed && !chartEntity.Prices[2].IsRed && !chartEntity.Prices[3].IsRed;
        _logger.LogInformation($"IsBuy validation is: {(result ? "true" : "false")}");
        return result;

    }

    public bool IsSell(TradingChartDto chartEntity)
    {
        _logger.LogInformation("Starting IsSell validation");
        if (!_tradingChartService.IsMovingUp(chartEntity)) return false;
        if (!_tradingChartService.IsEngulfing(chartEntity)) return false;
        var result = !chartEntity.Prices[0].IsRed &&
                     chartEntity.Prices[1].IsRed && chartEntity.Prices[2].IsRed && chartEntity.Prices[3].IsRed;
        _logger.LogInformation($"IsSell validation is: {(result ? "true" : "false")}");
        return result;
    }
}
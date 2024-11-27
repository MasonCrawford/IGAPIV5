using System.ComponentModel;
using Data.Dto;
using DataFactory.Interfaces;
using IgStreamerClient;
using Microsoft.Extensions.Logging;
using TradingService.Interfaces;

namespace DataFactory;

public class PricesDataService : IPricesDataService
{
    private readonly ILogger<PricesDataService> _logger;
    private readonly ITradingChartDataService _tradingChartDataService;
    private readonly ITradingChartService _tradingChartService;

    public PricesDataService(ILogger<PricesDataService> logger,
        ITradingChartDataService tradingChartDataService,
        ITradingChartService tradingChartService)
    {
        _logger = logger;
        _tradingChartDataService = tradingChartDataService;
        _tradingChartService = tradingChartService;
        
    }

    public async void HandlePricesUpdate(object sender, EventArgs e, string chartCode)
    {
        _logger.LogInformation($"Saving Price Info for chartCode {chartCode}");
        var empObj = (RTfeed) sender;
        var tradingChart = await _tradingChartDataService.GetFullTradingChart(chartCode);
        tradingChart.Prices.Insert(0,empObj.Prices);
        var movingAverage =_tradingChartService.CalculateMovingAverage(tradingChart);
        tradingChart.Prices.First().MovingAverage = movingAverage;

        try
        {
            _tradingChartDataService.Update(tradingChart);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
        }
    }

}
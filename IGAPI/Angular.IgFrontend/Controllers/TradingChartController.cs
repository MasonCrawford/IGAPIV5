using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Angular.IgFrontend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradingChartController : ControllerBase
{
    private readonly ILogger<TradingTargetController> _logger;
    private readonly ITradingChartDataService _tradingChartDataService;

    public TradingChartController(ILogger<TradingTargetController> logger, ITradingChartDataService tradingChartDataService)
    {
        _logger = logger;
        _tradingChartDataService = tradingChartDataService;
    }
    
    //todo add get codes
    [HttpGet("chartCodes")]
    public async Task<IEnumerable<string?>?> GetchartCodes()
    {
        return _tradingChartDataService.ChartCodes();
    }
    
    [HttpGet("getFull/{chartCode}")]
    public async Task<TradingChartDto?> Get(string chartCode)
    {
        return await _tradingChartDataService.GetFullTradingChart(chartCode);
    }
}
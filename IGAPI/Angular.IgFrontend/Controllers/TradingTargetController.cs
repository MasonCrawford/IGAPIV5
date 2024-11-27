using Common;
using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Angular.IgFrontend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradingTargetController : ControllerBase
{
    private readonly ILogger<TradingTargetController> _logger;
    private readonly IOrderDataService _orderDataService;
    private readonly ITradingTargetDataService _tradingTargetDataService;

    public TradingTargetController(ILogger<TradingTargetController> logger, IOrderDataService orderDataService,
        ITradingTargetDataService tradingTargetDataService)
    {
        _logger = logger;
        _orderDataService = orderDataService;
        _tradingTargetDataService = tradingTargetDataService;
    }

    [HttpGet]
    public async Task<IEnumerable<TradingTargetsDto>> Get()
    {
        return _tradingTargetDataService.Get();
    }

    [HttpGet("names")]
    public async Task<IEnumerable<KeyValuePair<Guid?, string>>> GetNames()
    {
        return _tradingTargetDataService.Get().Select(x => new KeyValuePair<Guid?, string>(x.Id, x.Name));
    }

    [HttpGet("getFull/{id}")]
    public async Task<TradingTargetsDto> GetFull(Guid id)
    {
        return _tradingTargetDataService.GetFullTradingTargetById(id);
    }

    [HttpGet("orders/{id}")]
    public async Task<IEnumerable<OrderDto>> GetOrders(Guid id)
    {
        return _orderDataService.GetOrdersByTradingTarget(id);
    }

    [HttpGet("orders/details/{id}")]
    public async Task<OrdersDetails> GetOrdersDetails(Guid id)
    {
        var orders = _orderDataService.GetOrdersByTradingTarget(id).Where(x => x.Profit.HasValue).ToList();
        var results = new OrdersDetails();
        results.TradeCount = orders.Count;
        if (results.TradeCount < 1)
            return results;
        results.WinLossRate = orders.Select(x => x.Profit > 0 ? 1 : 0)?.Average() ?? 0;
        results.TotalProfit = orders.Select(x => x.Profit)?.Sum() ?? 0;

        results.MinDeposit = orders.Select(x => x.Deposit)?.Min() ?? 0;
        results.MaxDeposit = orders.Select(x => x.Deposit)?.Max() ?? 0;

        orders.RemoveAt(orders.Count - 1);
        results.TotalProfitTrend = orders.Count > 0
            ? orders.Select(x => x.Profit)?.Sum() < results.TotalProfit ? Enums.trend.Up : Enums.trend.Down
            : Enums.trend.Minus;

        return results;
    }
}

//todo: move this to factory
public class OrdersDetails
{
    public double WinLossRate { get; set; }
    public decimal TotalProfit { get; set; }
    public Enums.trend TotalProfitTrend { get; set; }
    public int TradeCount { get; set; }
    public decimal MinDeposit { get; set; }
    public decimal MaxDeposit { get; set; }
}
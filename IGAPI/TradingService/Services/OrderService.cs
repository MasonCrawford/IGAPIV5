using Data.Dto;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using TradingService.Interfaces;

namespace TradingService.Services;

public class OrderService : IOrderService
{
    private readonly ILogger<IOrderService> _logger;

    public OrderService(ILogger<IOrderService> logger)
    {
        _logger = logger;
    }

    public decimal CalMargin(decimal withoutMargin, IEnumerable<DepositBandDto> depositBands)
    {
        var margin = depositBands?.FirstOrDefault(x =>
            x.Min < withoutMargin && x.Max > withoutMargin)
            ?.Margin ?? 0;
        return withoutMargin / margin;
    }
    
    public decimal CalContractSize(decimal withMargin)
    {
        return Math.Round(withMargin / 1000, 2);
    }
    
    public decimal CalTargetAmount(decimal withMargin, decimal targetPercent)
    {
        return Math.Round(withMargin * targetPercent, 2);
    }
    
    public decimal CalRiskAmount(decimal withMargin, decimal riskPercent)
    {
        return Math.Round(withMargin * riskPercent, 2);
    }
    
}
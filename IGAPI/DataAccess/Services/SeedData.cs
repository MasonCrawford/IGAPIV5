using Common;
using DataAccess.Entities;
using DataAccess.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Services;

public class SeedData : ISeedData
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SeedData(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void Seed()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        remove();

        context.Program.Add(new ProgramEntity
        {
            IsActive = true,
            ReSeed = false
        });

        context.TradingTargets.Add(new TradingTargetEntity
        {
            Epic = "CS.D.BITCOIN.CFD.IP",
            ChartCode = "BTC",
            CurrencyCode = "USD",
            Status = Enums.status.Closed,
            Method = Enums.method.BigOrBust,
            Profit = 0,
            RiskPercent = (decimal) 0.015,
            TargetPercent = (decimal) 0.02,
            Orders = new List<OrdersEntity>(),
            InitialDeposit = 1557,
            MovingAverageLength = 100,
            TradingLevel = 0
        });

        context.TradingTargets.Add(new TradingTargetEntity
        {
            Epic = "CS.D.AUDUSD.MINI.IP",
            ChartCode = "AUDUSD",
            CurrencyCode = "USD",
            Status = Enums.status.Active,
            Method = Enums.method.BigOrBust,
            Profit = 0,
            RiskPercent = (decimal) 0.01,
            TargetPercent = (decimal) 0.01,
            Orders = new List<OrdersEntity>(),
            InitialDeposit = 2000,
            MovingAverageLength = 50,
            TradingLevel = 0
        });

        context.TradingChart.Add(new TradingChartEntity
        {
            ChartCode = "AUDUSD",
            Prices = new List<PricesEntity>()
        });

        context.TradingChart.Add(new TradingChartEntity
        {
            ChartCode = "BTC",
            Prices = new List<PricesEntity>()
        });

        context.SaveChanges();
    }

    private void remove()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        context.DepositBand.RemoveRange(context.DepositBand);
        context.Orders.RemoveRange(context.Orders);
        context.TradingTargets.RemoveRange(context.TradingTargets);
        context.Prices.RemoveRange(context.Prices);
        context.Price.RemoveRange(context.Price);
        context.ApplicationLogs.RemoveRange(context.ApplicationLogs);

        context.TradingChart.RemoveRange(context.TradingChart);
        context.Program.RemoveRange(context.Program);

        context.SaveChanges();
    }
}
using Data.Dto;

namespace TradeLoop.Services.Interfaces;

public interface ISubscriptionInitializationService
{
    void SubscriptionConnect();
    Task SubscriptionInitialization(Func<Task<int>> method, TradingTargetsDto tradingTargetsDto);
}
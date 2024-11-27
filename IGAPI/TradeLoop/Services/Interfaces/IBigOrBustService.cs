namespace TradeLoop.Services.Interfaces;

public interface IBigOrBustService
{
    Task<int> Start(Guid? tradingTargetId);
}
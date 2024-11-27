using Data.Dto;

namespace DataFactory.Interfaces;

public interface ITrailingStopService
{
    Task Start(string dealId, decimal currentLevel, decimal trailingStopDistance = 0.015M, decimal trailingTargetPercent = 0.02M);
    void HandlePricesUpdate(object sender, EventArgs e, string dealId, TradingTargetsDto tradingTarget);
    void UnSubscribeTrailingStop(string dealId);
    Task SubscribeTrailingStop(TradingTargetsDto tradingTarget, string? dealId);
}
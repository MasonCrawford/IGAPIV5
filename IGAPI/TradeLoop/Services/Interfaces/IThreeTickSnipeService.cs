using Data.Dto;

namespace TradeLoop.Services.Interfaces;

public interface IThreeTickSnipeService
{
    Task<int> Start(Guid? tradingTargetId);
}
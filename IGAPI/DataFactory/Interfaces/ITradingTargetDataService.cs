using Common;
using Data.Dto;
using DataAccess.Entities;

namespace DataFactory.Interfaces;

public interface ITradingTargetDataService : IBaseDataScervice<TradingTargetEntity, TradingTargetsDto>
{
    List<TradingTargetsDto> Get();
    TradingTargetsDto? GetFullTradingTargetById(Guid? id);
    Task SeedMarketValues();
    Task<Enums.status> UpdatePosition(Guid? id);
    Task<string> PlaceOrder(TradingTargetsDto tradingTarget, Enums.orderAction orderAction);

}
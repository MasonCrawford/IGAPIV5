using Common;
using Data.Dto;
using DataAccess.Entities;

namespace DataFactory.Interfaces;

public interface IOrderDataService : IBaseDataScervice<OrdersEntity, OrderDto>
{
    IEnumerable<OrderDto> GetOrdersByTradingTarget(Guid tradingTargetId);
    OrderDto? GetLastClosedOrderByTradingTarget(Guid? tradingTargetId);
    OrderDto CreateOrder(TradingTargetsDto tradingTarget);
    OrderDto? GetOrderDtoByDealId(string dealId);
    void Update(OrderDto order);
}
using DataAccess.Entities;
using DataAccess.Repository.Common;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repository;

public class OrdersRepository : BaseRepository<OrdersEntity>
{
    public OrdersRepository(IServiceScopeFactory scopeFactory) : base(scopeFactory)
    {
    }

    public IEnumerable<OrdersEntity> Get(Guid tradingTargetId)
    {
        return base.Get(orders => orders.TradingTargetEntity.Id == tradingTargetId,
            queryable => queryable.OrderBy(x => x.CreatedOnUtc));
    }
}
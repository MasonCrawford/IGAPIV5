using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repository.Interfaces;

public interface ITradingChartRepository
{
    IEnumerable<TradingChartEntity> Get(Expression<Func<TradingChartEntity, bool>>? filter = null,
        Func<IQueryable<TradingChartEntity>, IOrderedQueryable<TradingChartEntity>>? orderBy = null,
        params Expression<Func<TradingChartEntity, object>>[] includeProperties);

    TradingChartEntity GetById(params object[] id);
    void Insert(TradingChartEntity entity);
    void Update(TradingChartEntity entityToUpdate);
    void Delete(params object[] id);
    void Delete(TradingChartEntity entityToDelete);
}
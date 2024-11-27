using DataAccess.Entities;
using DataAccess.Repository.Common;
using DataAccess.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repository;

public class TradingChartRepository : BaseRepository<TradingChartEntity>, ITradingChartRepository
{
    public TradingChartRepository(IServiceScopeFactory scopeFactory) : base(scopeFactory)
    {
    }
    
}
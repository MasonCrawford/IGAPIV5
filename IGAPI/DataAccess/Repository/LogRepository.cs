using DataAccess.Entities;
using DataAccess.Repository.Common;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repository;

public class LogRepository : BaseRepository<LogEntity>, ILogRepository
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<LogRepository> _logger;

    public LogRepository(IServiceScopeFactory scopeFactory, ILogger<LogRepository> logger) : base(scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public IEnumerable<string> Categories()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        return context.ApplicationLogs.Select(x => x.CategoryName).Distinct().ToList();
    }

    public void RemoveOldLogs(string levelToRemove, int dayToKeep = -1)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var oldDate = DateTime.Now.AddDays(dayToKeep);
        var oldLogs =
            context.ApplicationLogs.Where(log =>
                log.LogLevel == levelToRemove && log.CreatedOnUtc < oldDate).ToList();
        
        _logger.LogWarning($"Removing {oldLogs.Count()} {levelToRemove} logs");
        context.RemoveRange(oldLogs);
        context.SaveChanges();

    }
}
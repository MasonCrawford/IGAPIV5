using DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repository.Interfaces;

public interface ILogRepository : IEntityRepository<LogEntity>
{
    IEnumerable<string> Categories();

    void RemoveOldLogs(string levelToRemove, int dayToKeep = -1);
}
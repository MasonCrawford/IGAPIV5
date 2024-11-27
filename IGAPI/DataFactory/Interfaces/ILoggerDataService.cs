using Data.Dto;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace DataFactory.Interfaces;

public interface ILoggerDataService : IBaseDataScervice<LogEntity, LogDto>
{
    IEnumerable<LogDto> GetAll(int pageNumber = 1,int pageSize= 25);
    IEnumerable<LogDto> Get(LogLevel logLevel, string? category = null, int pageNumber = 1, int pageSize = 25);
    public IEnumerable<LogDto> Get(string category, int pageNumber = 1, int pageSize = 25);
    void Log(LogDto dto);
    void RemoveOldLogs(LogLevel levelToRemove = LogLevel.Information, int dayToKeep = -3);
    IEnumerable<string> Categories();
    public int Count(LogLevel? logLevel, string? category = null);
    public int Count(string? category = null);
}
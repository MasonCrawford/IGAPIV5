using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory.Interfaces;
using Microsoft.Extensions.Logging;

namespace DataFactory;

public class LoggerDataService : ILoggerDataService
{
    private readonly ILogRepository _logRepository;

    public LoggerDataService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }


    public IEnumerable<LogDto> GetAll(int pageNumber = 1,int pageSize= 25)
    {
        return _logRepository.GetPaged(pageNumber, pageSize, null, entities => entities.OrderByDescending(x => x.Timestamp)).Select(Map);
    }

    public int Count(LogLevel? logLevel, string? category = null)
    {
        return category != null
            ? _logRepository.Count(
                entity => entity.LogLevel == logLevel.ToString() &&
                          entity.CategoryName == category)
            : _logRepository.Count(entity => entity.LogLevel == logLevel.ToString());
    }

    public IEnumerable<LogDto> Get(LogLevel logLevel, string? category = null, int pageNumber = 1,int pageSize= 25)
    {
        return category != null
            ? _logRepository.GetPaged(pageNumber, pageSize,
                    entity => entity.LogLevel == logLevel.ToString() &&
                              entity.CategoryName == category, entities => entities.OrderByDescending(x => x.Timestamp))
                .Select(Map)
            : _logRepository.GetPaged(pageNumber, pageSize,entity => entity.LogLevel == logLevel.ToString(),
                    entities => entities.OrderByDescending(x => x.Timestamp))
                .Select(Map);
    }
    
    public int Count(string? category= null)
    {
        return category != null ? _logRepository.Count(entity => entity.CategoryName == category):_logRepository.Count();
    }

    public IEnumerable<LogDto> Get(string category, int pageNumber = 1,int pageSize= 25)
    {
        return  _logRepository.GetPaged(pageNumber, pageSize,entity => entity.CategoryName == category,
                    entities => entities.OrderByDescending(x => x.Timestamp))
                .Select(Map);
    }

    public void Log(LogDto dto)
    {
        _logRepository.Insert(Map(dto));
    }

    public IEnumerable<string> Categories()
    {
        return _logRepository.Categories();
    }
    
    public void RemoveOldLogs(LogLevel levelToRemove = LogLevel.Information, int dayToKeep = -7)
    {
        _logRepository.RemoveOldLogs(levelToRemove.ToString(), dayToKeep);
    }

    public LogDto Map(LogEntity entity)
    {
        return new LogDto
        {
            Id = entity.Id,
            CreatedOnUtc = entity.CreatedOnUtc,
            LastModifiedOnUtc = entity.LastModifiedOnUtc,
            Msg = entity.Msg,
            Timestamp = entity.Timestamp,
            User = entity.User,
            CategoryName = entity.CategoryName,
            LogLevel = entity.LogLevel
        };
    }

    public LogEntity Map(LogDto dto)
    {
        return new LogEntity
        {
            Id = dto.Id??new Guid(),
            CreatedOnUtc = dto.CreatedOnUtc,
            LastModifiedOnUtc = dto.LastModifiedOnUtc,
            Msg = dto.Msg,
            Timestamp = dto.Timestamp,
            User = dto.User,
            CategoryName = dto.CategoryName,
            LogLevel = dto.LogLevel
        };
    }
}
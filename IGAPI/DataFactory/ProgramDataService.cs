using Data.Dto;
using DataAccess;
using DataAccess.Entities;
using DataFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataFactory;

public class ProgramDataService : IProgramDataService
{
    private readonly IServiceScopeFactory _scopeFactory;
    
    public ProgramDataService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public ProgramEntity? Get()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        return context.Program.FirstOrDefault();
    }

    public async Task<bool> GetIsActive()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        await context.Entry(Get()).ReloadAsync();
        return context?.Program?.FirstOrDefault()?.IsActive ?? false;
    }

    public ProgramDto Map(ProgramEntity entity)
    {
        return new ProgramDto
        {
            Id = entity.Id,
            CreatedOnUtc = entity.CreatedOnUtc,
            LastModifiedOnUtc = entity.LastModifiedOnUtc,
            IsActive = entity.IsActive,
            ReSeed = entity.ReSeed
        };
    }

    public ProgramEntity Map(ProgramDto dto)
    {
        return new ProgramEntity
        {
            Id = dto.Id??new Guid(),
            CreatedOnUtc = dto.CreatedOnUtc,
            LastModifiedOnUtc = dto.LastModifiedOnUtc,
            IsActive = dto.IsActive,
            ReSeed = dto.ReSeed
        };
    }
}
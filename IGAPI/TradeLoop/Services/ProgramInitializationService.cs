using DataAccess;
using DataAccess.Services.Interfaces;
using DataFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;

namespace TradeLoop.Services;

public class ProgramInitializationService : IProgramInitializationService
{
    private readonly ILogger<ProgramInitializationService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IProgramDataService _programDataService;
    private readonly ISeedData _seedData;
    private readonly ITradingChartDataService _tradingChartDataService;
    private readonly ITradingTargetDataService _tradingTargetDataService;

    public ProgramInitializationService(IServiceScopeFactory scopeFactory, IProgramDataService programDataService,
        ISeedData seedData, ITradingChartDataService tradingChartDataService,
        ILogger<ProgramInitializationService> logger, ITradingTargetDataService tradingTargetDataService)
    {
        _scopeFactory = scopeFactory;
        _programDataService = programDataService;
        _seedData = seedData;
        _tradingChartDataService = tradingChartDataService;
        _logger = logger;
        _tradingTargetDataService = tradingTargetDataService;
    }

    public async Task ProgramInitialization()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        _logger.LogInformation("Initializing Program");
        await context.Database.MigrateAsync();
        var program = _programDataService.Get();
        if (program == null || program.ReSeed)
        {
            _seedData.Seed();
            _logger.LogWarning("Seeded Data");
            //todo: re auth at this point to avoid lost token after long running seed  
        }

        await _tradingTargetDataService.SeedMarketValues();
        await _tradingChartDataService.RemoveOldPrices();
    }
}
using DataFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataFactory.Extensions;

/// <summary>
///     Extension methods for Data Factory Services.
/// </summary>
public static class DataFactoryServicesExtensions
{
    /// <summary>
    ///     Adds Data Factory Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddDataFactoryServices(this IServiceCollection services)
    {
        services.AddTransient<ILoggerDataService, LoggerDataService>();
        
        services.AddSingleton<IPricesDataService, PricesDataService>();
        services.AddSingleton<IOrderDataService, OrderDataService>();
        services.AddSingleton<IProgramDataService, ProgramDataService>();
        services.AddSingleton<ITradingChartDataService, TradingChartDataService>();
        services.AddSingleton<ITradingTargetDataService, TradingTargetDataService>();
        // services.AddSingleton<ITrailingStopService, TrailingStopService>();
        return services;
    }
}
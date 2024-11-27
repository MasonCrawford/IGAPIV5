using Microsoft.Extensions.DependencyInjection;
using TradingService.Interfaces;
using TradingService.Services;

namespace TradingService.Extensions;

/// <summary>
///     Extension methods for Trading Services.
/// </summary>
public static class TradingServicesExtensions
{
    /// <summary>
    ///     Adds Trading Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddTradingServices(this IServiceCollection services)
    {
        services.AddTransient<ITradingChartService, TradingChartService>();
        services.AddTransient<IOrderService, OrderService>();
        return services;
    }
}
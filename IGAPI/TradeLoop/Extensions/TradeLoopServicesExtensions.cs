using Microsoft.Extensions.DependencyInjection;
using TradeLoop.Services;
using TradeLoop.Services.Interfaces;

namespace TradeLoop.Extensions;

/// <summary>
///     Extension methods for Trade Loop Services.
/// </summary>
public static class TradeLoopServicesExtensions
{
    /// <summary>
    ///     Adds Trade Loop Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddTradeLoopServices(this IServiceCollection services)
    {
        services.AddSingleton<IAccessService, AccessService>();
        services.AddTransient<IProgramInitializationService, ProgramInitializationService>();
        services.AddSingleton<ISubscriptionInitializationService, SubscriptionInitializationService>();
        services.AddTransient<ITradingTargetsLoop, TradingTargetsLoop>();
        services.AddTransient<IThreeTickSnipeService, ThreeTickSnipeService>();
        services.AddTransient<IBigOrBustService, BigOrBustService>();
        return services;
    }
}
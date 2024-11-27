using Microsoft.Extensions.DependencyInjection;

namespace IgStreamerClient.Extensions;

/// <summary>
///     Extension methods for Ig Streamer Client Services.
/// </summary>
public static class IgStreamerClientServicesExtensions
{
    /// <summary>
    ///     Adds Ig Streamer Client Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddIgStreamerClientServices(this IServiceCollection services)
    {
        services.AddSingleton<IRTfeed, RTfeed>();
        services.AddSingleton<ICandleDataListener, CandleDataListener>();
        services.AddSingleton<ITickDataListener, TickDataListener>();
        services.AddSingleton<ITestConnectionListener, TestConnectionListener>();
        return services;
    }
}
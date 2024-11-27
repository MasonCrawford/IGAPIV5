using IgClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IgClient.Extensions;

/// <summary>
///     Extension methods for Ig Client Services.
/// </summary>
public static class IgClientServicesExtensions
{
    /// <summary>
    ///     Adds Ig Client Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddIgClientServices(this IServiceCollection services)
    {
        services.AddSingleton<IIgRestService, IgRestService>();
        services.AddSingleton<IIgRestApiClient, IgRestApiClient>();
        return services;
    }
}
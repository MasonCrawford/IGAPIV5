using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.Common;
using DataAccess.Repository.Interfaces;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

/// <summary>
///     Extension methods for Data access Services.
/// </summary>
public static class DataAccessServicesExtensions
{
    /// <summary>
    ///     Adds Data access Services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        ServiceLifetime contextServiceLifetime)
    {
        services.AddDbContext<TradingAppContext>(contextServiceLifetime);
        services.AddSingleton<IEntityRepository<TradingTargetEntity>, BaseRepository<TradingTargetEntity>>();
        services.AddSingleton<IEntityRepository<PricesEntity>, BaseRepository<PricesEntity>>();
        services.AddSingleton<IEntityRepository<DepositBandEntity>, BaseRepository<DepositBandEntity>>();
        services.AddSingleton<ILogRepository, LogRepository>();

        services.AddSingleton<ITradingChartRepository, TradingChartRepository>();
        services.AddSingleton<IEntityRepository<OrdersEntity>, OrdersRepository>();

        services.AddSingleton<ISeedData, SeedData>();

        return services;
    }
}
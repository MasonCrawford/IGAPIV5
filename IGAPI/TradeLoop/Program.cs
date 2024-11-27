using Azure.Identity;
using DataAccess.Extensions;
using DataFactory.Extensions;
using IgClient.Extensions;
using IgStreamerClient.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeLoop.Extensions;
using TradeLoop.Providers;
using TradingService.Extensions;

namespace TradeLoop;

public class Program
{
    private static async Task<int> Main(string[] args)
    {
        var host = CreateHostBuilder();
        await host.RunConsoleAsync();
        return Environment.ExitCode;
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Error);
                logging.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Error);
                logging.AddDatabaseLogger();
                logging.AddConsole();
            })
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                if (hostContext.HostingEnvironment.IsDevelopment())
                {
                    builder.AddUserSecrets<Program>();
                }
                else
                {
                    var kvUri = "https://ig-api-keys.vault.azure.net/";
                    builder.AddAzureKeyVault(new Uri(kvUri), new DefaultAzureCredential());
                }
                //builder.AddEnvironmentVariables();
            })
            .ConfigureServices(services =>
            {
                services.AddDataFactoryServices();
                services.AddDataAccessServices(ServiceLifetime.Scoped);
                services.AddIgClientServices();
                services.AddIgStreamerClientServices();
                services.AddTradingServices();
                services.AddTradeLoopServices();


                services.AddHostedService<Worker>();
            });
    }
}
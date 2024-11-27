using DataFactory.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;

namespace TradeLoop;

public class Worker : IHostedService
{
    private readonly IAccessService _accessService;
    private readonly IHostApplicationLifetime _hostLifetime;
    private readonly ILogger<Worker> _logger;
    private readonly IProgramDataService _programDataService;
    private readonly IProgramInitializationService _programInitializationService;
    private readonly ISubscriptionInitializationService _subscriptionInitializationService;
    private readonly ITradingTargetsLoop _tradingTargetsLoop;
    private readonly ILoggerDataService _loggerDataService;
    private int? _exitCode;

    public Worker(IHostApplicationLifetime hostLifetime,
        IProgramInitializationService programInitializationService,
        ILogger<Worker> logger,
        IAccessService accessService,
        IProgramDataService programDataService,
        ISubscriptionInitializationService subscriptionInitializationService,
        ITradingTargetsLoop tradingTargetsLoop,
        ILoggerDataService loggerDataService)
    {
        _hostLifetime = hostLifetime ?? throw new ArgumentNullException(nameof(hostLifetime));
        _programInitializationService = programInitializationService;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accessService = accessService ?? throw new ArgumentNullException(nameof(accessService));
        _programDataService = programDataService ?? throw new ArgumentNullException(nameof(programDataService));
        _subscriptionInitializationService = subscriptionInitializationService ??
                                             throw new ArgumentNullException(nameof(subscriptionInitializationService));
        _tradingTargetsLoop = tradingTargetsLoop ?? throw new ArgumentNullException(nameof(tradingTargetsLoop));
        _loggerDataService = loggerDataService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var token = await _accessService.RefreshToken();
            if (token == null) throw new AccessViolationException("There was an issue authenticating.");

            _logger?.LogInformation("Starting Initialization");

            await _programInitializationService.ProgramInitialization();
            _subscriptionInitializationService.SubscriptionConnect();
            await _tradingTargetsLoop.start();

            while (token != null && await _programDataService.GetIsActive())
            {
                _logger?.LogInformation("Starting application loop");
                
                try
                {
                    _logger?.LogInformation("Application loop Running, Starting sleep");
                    Thread.Sleep((int) TimeSpan.FromMinutes(0.9).TotalMilliseconds);
                    token = await _accessService.RefreshToken();
                    _loggerDataService.RemoveOldLogs();
                    _loggerDataService.RemoveOldLogs(LogLevel.Warning);
                }
                catch (Exception e)
                {
                    _logger?.LogError($"An error occurred in the trading loop: {e.Message}");
                    _exitCode = 1;
                    break;
                }
            }

            _logger?.LogInformation(
                $"Application closed Program IsActive Was: {(await _programDataService.GetIsActive() ? "true" : "false")}");
            _exitCode = 0;
        }
        catch (OperationCanceledException)
        {
            _logger?.LogInformation("The job has been killed with CTRL+C");
            _exitCode = -1;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "An error occurred");
            _exitCode = 1;
        }
        finally
        {
            _hostLifetime.StopApplication();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
        _logger?.LogWarning($"Shutting down the service with code {Environment.ExitCode}");
        return Task.CompletedTask;
    }
}
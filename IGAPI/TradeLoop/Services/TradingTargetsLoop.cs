using Common;
using DataFactory.Interfaces;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;

namespace TradeLoop.Services;

public class TradingTargetsLoop : ITradingTargetsLoop
{
    private readonly ILogger<TradingTargetsLoop> _logger;
    private readonly IThreeTickSnipeService _threeTickSnipeService;
    private readonly IBigOrBustService _bigOrBustService;
    private readonly ITradingTargetDataService _tradingTargetDataService;
    private ISubscriptionInitializationService _subscriptionInitializationService;

    public TradingTargetsLoop(ITradingTargetDataService tradingTargetDataService, ILogger<TradingTargetsLoop> logger,
        IThreeTickSnipeService threeTickSnipeService, ISubscriptionInitializationService subscriptionInitializationService, IBigOrBustService bigOrBustService)
    {
        _tradingTargetDataService = tradingTargetDataService;
        _logger = logger;
        _threeTickSnipeService = threeTickSnipeService;
        _subscriptionInitializationService = subscriptionInitializationService;
        _bigOrBustService = bigOrBustService;
    }

    public async Task<int> start()
    {
        //todo: look into how / why the app stopped at this point and how it can be fixed 
        var targets = _tradingTargetDataService.Get();
        foreach (var t in targets)
        {
            var tradingTarget = _tradingTargetDataService.GetFullTradingTargetById(t.Id);
            _logger.LogInformation($"Enter Trading Loop for: {tradingTarget.Epic} at {DateTime.Now}");
            switch (tradingTarget.Method)
            {
                case Enums.method.TreeTickSnipe:
                    _logger.LogInformation("Starting three Tick Snipe");
                    await _subscriptionInitializationService.SubscriptionInitialization(() => _threeTickSnipeService.Start(tradingTarget.Id),
                        tradingTarget);
                    break;
                case Enums.method.BigOrBust:
                    _logger.LogInformation("Starting Big Or Bust");
                    await _subscriptionInitializationService.SubscriptionInitialization(
                        () => _bigOrBustService.Start(tradingTarget.Id),
                        tradingTarget);
                    break;
                default:
                    _logger.LogError(
                        $"no implementation for the method ({tradingTarget.Method}) on {tradingTarget.Name}");
                    throw new ArgumentOutOfRangeException();
            }
        }

        return 0;
    }
}
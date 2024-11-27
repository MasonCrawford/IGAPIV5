using System.ComponentModel;
using Common;
using Data.Dto;
using DataAccess;
using DataFactory.Interfaces;
using IgStreamerClient;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;

namespace TradeLoop.Services;

//todo: handle System.IO.IOException: Channel is closed
public class SubscriptionInitializationService : ISubscriptionInitializationService
{

    private readonly ILogger<SubscriptionInitializationService> _logger;
    private readonly IRTfeed _lsClient;
    private readonly IPricesDataService _pricesDataService;
    
    public SubscriptionInitializationService(ILogger<SubscriptionInitializationService> logger,
        IRTfeed lsClient,
        IPricesDataService pricesDataService,
        ITradingTargetDataService tradingTargetDataService, ITrailingStopService trailingStopService)
    {
        _logger = logger;
        _lsClient = lsClient;
        _pricesDataService = pricesDataService;
    }


    public void SubscriptionConnect()
    {
        _logger.LogInformation("Initializing Subscription");
        _lsClient.Connect();
    }

    public async Task SubscriptionInitialization(Func<Task<int>> method, TradingTargetsDto tradingTarget)
    {
        _logger.LogInformation($"Starting Subscribe for {tradingTarget.Epic}");
        _lsClient.SubscribeCandleData(tradingTarget.Epic);
        _lsClient.SubscribeTickData(tradingTarget.Epic);

        if (tradingTarget.ChartCode == null)
        {
            _logger.LogError($"Subscription failed for {tradingTarget.Name}: no chart code was provided");
        }
        else
        {
            _lsClient.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName != "Prices") return;
                _pricesDataService.HandlePricesUpdate(sender, e, tradingTarget.ChartCode);
                method.Invoke();
            };
        }
    }
}
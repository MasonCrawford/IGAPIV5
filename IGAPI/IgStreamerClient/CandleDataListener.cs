using com.lightstreamer.client;
using Data.Dto;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace IgStreamerClient;

public class CandleDataListener : ICandleDataListener
{
    private readonly ILogger<CandleDataListener> _logger;
    private RTfeed rTfeed;

    public CandleDataListener(ILogger<CandleDataListener> logger)
    {
        _logger = logger;
    }

    public void InIt(RTfeed rTfeed)
    {
        this.rTfeed = rTfeed;
    }

    // ---

    void SubscriptionListener.onClearSnapshot(string itemName, int itemPos)
    {
        _logger.LogInformation("Clear snapshot evernt received for " + itemName);
    }

    void SubscriptionListener.onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
    {
        throw new NotImplementedException();
    }

    void SubscriptionListener.onCommandSecondLevelSubscriptionError(int code, string message, string key)
    {
        throw new NotImplementedException();
    }

    void SubscriptionListener.onEndOfSnapshot(string itemName, int itemPos)
    {
        _logger.LogInformation("End of snapshot received for " + itemName);
    }

    void SubscriptionListener.onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
    {
        _logger.LogInformation("Lost " + lostUpdates + " updates for " + itemName);
    }

    void SubscriptionListener.onItemUpdate(ItemUpdate update)
    {
        if (update.getValue(14) != "1") return;
        rTfeed.Prices = new PricesDto
        {
            HighPrice = new PriceDto
            {
                Bid = string.IsNullOrWhiteSpace(update.getValue(2)) ? null : decimal.Parse(update.getValue(2)),
                Ask = string.IsNullOrWhiteSpace(update.getValue(3)) ? null : decimal.Parse(update.getValue(3)),
                LastTraded = string.IsNullOrWhiteSpace(update.getValue(4))
                    ? null
                    : decimal.Parse(update.getValue(4))
            },
            LowPrice = new PriceDto
            {
                Bid = string.IsNullOrWhiteSpace(update.getValue(5)) ? null : decimal.Parse(update.getValue(5)),
                Ask = string.IsNullOrWhiteSpace(update.getValue(6)) ? null : decimal.Parse(update.getValue(6)),
                LastTraded = string.IsNullOrWhiteSpace(update.getValue(7))
                    ? null
                    : decimal.Parse(update.getValue(7))
            },
            OpenPrice = new PriceDto
            {
                Bid = string.IsNullOrWhiteSpace(update.getValue(8)) ? null : decimal.Parse(update.getValue(8)),
                Ask = string.IsNullOrWhiteSpace(update.getValue(9)) ? null : decimal.Parse(update.getValue(9)),
                LastTraded = string.IsNullOrWhiteSpace(update.getValue(10))
                    ? null
                    : decimal.Parse(update.getValue(10))
            },
            ClosePrice = new PriceDto
            {
                Bid = string.IsNullOrWhiteSpace(update.getValue(11)) ? null : decimal.Parse(update.getValue(11)),
                Ask = string.IsNullOrWhiteSpace(update.getValue(12)) ? null : decimal.Parse(update.getValue(12)),
                LastTraded = string.IsNullOrWhiteSpace(update.getValue(13))
                    ? null
                    : decimal.Parse(update.getValue(13))
            }
        };
        _logger.LogInformation(
            $"{NotifyUpdate(update)} for Candle Data received: At {update.getValue(1)}: candle was {update.getValue(14)}");
    }

    void SubscriptionListener.onListenEnd(Subscription subscription)
    {
        // ...
    }

    void SubscriptionListener.onListenStart(Subscription subscription)
    {
        // ...
    }

    void SubscriptionListener.onSubscription()
    {
        _logger.LogInformation("Subscription");
    }

    void SubscriptionListener.onSubscriptionError(int code, string message)
    {
        _logger.LogError("Subscription Error: " + message + " (" + code + ").");
    }

    void SubscriptionListener.onUnsubscription()
    {
        _logger.LogWarning("Unsubscription");
    }

    void SubscriptionListener.onRealMaxFrequency(string frequency)
    {
        _logger.LogInformation("Real Max Frequency: " + frequency);
    }

    public string NotifyUpdate(ItemUpdate update)
    {
        return update.Snapshot ? "snapshot" : "update";
    }
}
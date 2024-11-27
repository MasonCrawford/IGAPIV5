using com.lightstreamer.client;
using Data.Dto;
using Microsoft.Extensions.Logging;

namespace IgStreamerClient;

public class TickDataListener : ITickDataListener
{
    private readonly ILogger<ITickDataListener> _logger;
    private RTfeed rTfeed;

    public TickDataListener(ILogger<ITickDataListener> logger)
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
        if (update.getValue(3) != "1") return;

        if (!(string.IsNullOrWhiteSpace(update.getValue(1))||string.IsNullOrWhiteSpace(update.getValue(2))))
        {
            rTfeed.CurrentLimit = ( decimal.Parse(update.getValue(1)) + decimal.Parse(update.getValue(2))) / 2; 
        }
        // _logger.LogInformation(
        //     $"{NotifyUpdate(update)} for Tick Data");
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
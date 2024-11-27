using com.lightstreamer.client;

namespace IgStreamerClient;

public interface ICandleDataListener : SubscriptionListener
{
    void InIt(RTfeed rTfeed);
    string NotifyUpdate(ItemUpdate update);
}
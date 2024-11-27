using com.lightstreamer.client;

namespace IgStreamerClient;

public interface ITickDataListener : SubscriptionListener
{
    void InIt(RTfeed rTfeed);
    string NotifyUpdate(ItemUpdate update);
}
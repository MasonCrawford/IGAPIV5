using com.lightstreamer.client;

namespace IgStreamerClient;

public interface ITestConnectionListener : ClientListener
{
    void InIt(RTfeed rTfeed);
    void onListenEnd(LightstreamerClient client);
    void onListenStart(LightstreamerClient client);
    void onPropertyChange(string property);
    void onServerError(int errorCode, string errorMessage);
    void onStatusChange(string status);
}
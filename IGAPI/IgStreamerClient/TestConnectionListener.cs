using System.Drawing;
using com.lightstreamer.client;
using Microsoft.Extensions.Logging;

namespace IgStreamerClient;

public class TestConnectionListener : ClientListener, ITestConnectionListener
{
    private readonly ILogger<TestConnectionListener> _logger;
    private RTfeed rTfeed;

    public TestConnectionListener(ILogger<TestConnectionListener> logger)
    {
        _logger = logger;
    }
    // ---

    public void onListenEnd(LightstreamerClient client)
    {
        _logger.LogInformation("Listen End - " + client.Status + " - ");
    }

    public void onListenStart(LightstreamerClient client)
    {
        _logger.LogInformation("Listen Start - " + client.Status + " - ");
    }

    public void onPropertyChange(string property)
    {
        _logger.LogInformation("Property " + property + " changed: ");
        if (rTfeed.Ls != null)
        {
            if (property.Equals("serverInstanceAddress")) _logger.LogInformation($"Server Instance Address: {rTfeed.Ls.connectionDetails.ServerAddress}");
            if (property.Equals("sessionId")) _logger.LogInformation($"Session Id: {rTfeed.Ls.connectionDetails.SessionId}");
        }
    }

    public void onServerError(int errorCode, string errorMessage)
    {
        _logger.LogError("Server Error - " + errorMessage + " - " + errorCode);
        rTfeed.StatusText = "Server failure: " + errorMessage;
        rTfeed.StatusColor = Color.Red;
        rTfeed.Connect();
    }

    public void onStatusChange(string status)
    {
        _logger.LogInformation(" >>>>>>>>>>>>>>>>>> " + status + " - ");
        if (status.StartsWith("CONNECTED:WS"))
        {
            if (status.EndsWith("POLLING"))
            {
                _logger.LogInformation("Smart polling session started");
                rTfeed.StatusText = "Smart polling session started";
                rTfeed.StatusColor = Color.LightGreen;
            }
            else if (status.EndsWith("STREAMING"))
            {
                _logger.LogInformation("Streaming session started");
                rTfeed.StatusText = "Streaming session started";
                rTfeed.StatusColor = Color.DarkGreen;
            }

            //rTfeed.SubscribeAll();
        }
        else if (status.StartsWith("CONNECTED:HT"))
        {
            if (status.EndsWith("POLLING"))
            {
                _logger.LogInformation("Smart polling session started");
                rTfeed.StatusText = "Smart polling session started";
                rTfeed.StatusColor = Color.LightGreen;
            }
            else if (status.EndsWith("STREAMING"))
            {
                _logger.LogInformation("Streaming session started");
                rTfeed.StatusText = "Streaming session started";
                rTfeed.StatusColor = Color.DarkGreen;
            }

            //rTfeed.SubscribeAll();
        }
        else if (status.StartsWith("CONNECTING"))
        {
            _logger.LogInformation("Connecting ... ");
            rTfeed.StatusText = "Connecting ... ";
            rTfeed.StatusColor = Color.Orange;
        }
        else if (status.StartsWith("DISCONNECTED"))
        {
            _logger.LogWarning("Connection forcibly closed");
            rTfeed.StatusText = "Connection forcibly closed";
            rTfeed.StatusColor = Color.Red;
        }
        else if (status.StartsWith("STALLED"))
        {
            _logger.LogWarning("Connection no longer stalled");
            rTfeed.StatusText = "Connection no longer stalled";
            rTfeed.StatusColor = Color.YellowGreen;
        }
    }

    public void InIt(RTfeed rTfeed)
    {
        this.rTfeed = rTfeed;
    }
}
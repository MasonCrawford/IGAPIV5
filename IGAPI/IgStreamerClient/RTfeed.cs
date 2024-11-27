using System.ComponentModel;
using System.Drawing;
using System.Net;
using com.lightstreamer.client;
using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using IgClient.Interfaces;
using Microsoft.Extensions.Logging;
using TradingService.Interfaces;

namespace IgStreamerClient;

public class RTfeed : INotifyPropertyChanged, IRTfeed
{
    private readonly ICandleDataListener _candleDataListener;
    private readonly ITickDataListener _tickDataListener;
    private readonly IIgRestApiClient _client;
    private readonly ILogger<RTfeed> _logger;
    private readonly ITestConnectionListener _testConnectionListener;
    private readonly ITradingChartRepository _tradingChartRepository;
    private readonly ITradingChartService _tradingChartService;
    private Subscription _dtk;
    private Subscription _1min;
    private string _password;
    private PricesDto _prices;
    private string _pushServerUrl;
    private Subscription _stk;
    private string _user;
    public LightstreamerClient Ls;

    private Color statusColor;

    private string statusText;
    private decimal? _currentLimit;

    public RTfeed(ILogger<RTfeed> logger, IIgRestApiClient client, ICandleDataListener candleDataListener,
        ITestConnectionListener testConnectionListener, ITradingChartRepository tradingChartRepository,
        ITradingChartService tradingChartService, ITickDataListener tickDataListener)
    {
        _candleDataListener = candleDataListener;
        _logger = logger;
        _client = client;
        _testConnectionListener = testConnectionListener;
        _tradingChartRepository = tradingChartRepository;
        _tradingChartService = tradingChartService;
        _tickDataListener = tickDataListener;
    }

    public string StatusText
    {
        get => statusText;
        set
        {
            statusText = value;
            OnPropertyChanged("StatusText");
        }
    }

    public Color StatusColor
    {
        get => statusColor;
        set
        {
            statusColor = value;
            OnPropertyChanged("StatusColor");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public decimal? CurrentLimit
    {
        get => _currentLimit;
        set
        {
            _currentLimit = value;
            OnPropertyChanged("CurrentLimit");
        }
    }
    public PricesDto Prices
    {
        get => _prices;
        set
        {
            _prices = value;
            OnPropertyChanged("Prices");
        }
    }

    public void Disconnect()
    {
        if (Ls == null) return;
        Ls.disconnect();
        Ls = null;
    }

    public async void Connect()
    {
        _logger.LogInformation("attempting to fetch session details for connection");
        var sessionDetailsResponse = await _client.fetchSessionDetails();
        if (sessionDetailsResponse.StatusCode == HttpStatusCode.OK)
        {
            var serverUrl = sessionDetailsResponse.Response.lightstreamerEndpoint;
            var activeAccountId = sessionDetailsResponse.Response.accountId;
            var clientToken = sessionDetailsResponse.Response.cst;
            var xSecurityToken = sessionDetailsResponse.Response.xSecurityToken;
            _pushServerUrl = serverUrl;
            _user = activeAccountId;
            _password = $"CST-{clientToken}|XST-{xSecurityToken}";
        }
        else
        {
            _logger.LogError($"failed to fetch session details response was: {sessionDetailsResponse.StatusCode} ");
            throw new AccessViolationException();
        }

        var noException = true;

        // Start a new attempt to connect to Lightstreamer server.
        if (Ls != null)
        {
            Ls.disconnect();
            Thread.Sleep(1500);
        }

        while (noException)
            try
            {
                Ls = new LightstreamerClient(_pushServerUrl, null);
                Ls.connectionDetails.User = _user;
                Ls.connectionDetails.Password = _password;
                _testConnectionListener.InIt(this);
                Ls.addListener(_testConnectionListener);
                Ls.connect();
                noException = false;
            }
            catch (Exception e)
            {
                _logger.LogError("Connection failure: " + e.Message + " - " + e.StackTrace);
            }

        _logger.LogInformation("Connection ... ");
    }

    public void UnSubscribeDetails()
    {
        if (_dtk != null)
        {
            var taskA = new Task(() =>
            {
                try
                {
                    Ls.unsubscribe(_dtk);
                }
                catch (Exception e)
                {
                    _logger.LogError("Lightstreamer Unsubscribe error: " + e.Message);
                }
            });

            // Start the task.
            taskA.Start();
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="epic"></param>
    /// <param name="scale">1MINUTE|5MINUTE</param>
    public void SubscribeCandleData(string epic, string scale = "5MINUTE")
    {
        var schemaName = new string[14]
        {
            "UTM", "BID_HIGH", "OFR_HIGH", "LTP_HIGH", "BID_LOW", "OFR_LOW", "LTP_LOW", "BID_OPEN", "OFR_OPEN",
            "LTP_OPEN", "BID_CLOSE", "OFR_CLOSE", "LTP_CLOSE", "CONS_END"
        };
        if (_dtk != null)
        {
            _logger.LogError("Here not expected!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            var taskA = new Task(() =>
            {
                try
                {
                    Ls.unsubscribe(_dtk);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Lightstreamer Unsubscribe error:{e.Message}");
                }
            });

            // Start the task.
            taskA.Start();
            Thread.Sleep(700);
        }


        _logger.LogInformation($"Subscribe Candle Data for {epic} at scale: {scale}");
        _dtk = new Subscription("MERGE", $"CHART:{epic}:{scale}", schemaName);
        _dtk.RequestedSnapshot = "yes";
        _dtk.RequestedMaxFrequency = "1.0";
        try
        {
            _candleDataListener.InIt(this);
            _dtk.addListener(_candleDataListener);
            Ls.subscribe(_dtk);
        }
        catch (Exception e)
        {
            _logger.LogError($"Candle Data {e.Message}");
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="epic"></param>
    public void SubscribeTickData(string epic)
    {
        var schemaName = new string[3]
        {
            "BID_CLOSE", "OFR_CLOSE", "CONS_END"
        };
        if (_1min != null)
        {
            _logger.LogError("Here not expected!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            var taskA = new Task(() =>
            {
                try
                {
                    Ls.unsubscribe(_1min);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Lightstreamer Unsubscribe error:{e.Message}");
                }
            });

            // Start the task.
            taskA.Start();
            Thread.Sleep(700);
        }


        _logger.LogInformation($"Subscribe Tick Data for {epic}");
        _1min = new Subscription("MERGE", $"CHART:{epic}:1MINUTE", schemaName);
        _1min.RequestedSnapshot = "yes";
        _1min.RequestedMaxFrequency = "1.0";
        try
        {
            _tickDataListener.InIt(this);
            _1min.addListener(_tickDataListener);
            Ls.subscribe(_1min);
        }
        catch (Exception e)
        {
            _logger.LogError($"Candle Data {e.Message}");
        }
    }
    
    

    private void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }

    private void OnPropertyChanged(string propertyName)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }
}
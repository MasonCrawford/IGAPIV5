using System.ComponentModel;
using Data.Dto;

namespace IgStreamerClient;

public interface IRTfeed
{
    event PropertyChangedEventHandler PropertyChanged;
    PricesDto Prices { get; set; }
    void Disconnect();
    void Connect();
    void UnSubscribeDetails();
    void SubscribeCandleData(string? epic, string scale = "5MINUTE");
    void SubscribeTickData(string? epic);
}
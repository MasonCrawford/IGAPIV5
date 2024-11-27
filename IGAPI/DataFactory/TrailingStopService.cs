using System.ComponentModel;
using System.Net;
using Common;
using Data.Dto;
using DataFactory.Interfaces;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.positions.edit.v1;
using IgStreamerClient;
using Microsoft.Extensions.Logging;
using TradingService.Services;
using ITrailingStopService = DataFactory.Interfaces.ITrailingStopService;

namespace DataFactory;

public class TrailingStopService : ITrailingStopService
{
    private readonly ILogger<ITrailingStopService> _logger;
    private readonly IIgRestApiClient _client;
    private readonly IRTfeed _lsClient;
    private Dictionary<string, System.ComponentModel.PropertyChangedEventHandler> _trailingStopsByDealId;
    private readonly IOrderDataService _orderDataService;
    public TrailingStopService(ILogger<ITrailingStopService> logger, IIgRestApiClient client, IOrderService orderService, IOrderDataService orderDataService, IRTfeed lsClient)
    {
        _logger = logger;
        _client = client;
        _orderDataService = orderDataService;
        _lsClient = lsClient;
        _trailingStopsByDealId = new Dictionary<string, PropertyChangedEventHandler>();
    }

    public async Task Start(string dealId, decimal currentLevel, decimal trailingStopDistance = 0.015m, decimal trailingTargetPercent = 0.02m)
    {
        var order = _orderDataService.GetOrderDtoByDealId(dealId);

        if (order == null)
        {
            _logger.LogError($"No order found for deal ID {dealId}");
            return;
        }

        if (!order.IsOpen)
        {
            _logger.LogInformation($"Order: {order.OrderId}, is closed not updating stop limit");
            return;
        }
        
        var shouldUpdate = order.OrderAction == Enums.orderAction.BUY
            ? order.LastKnowPrice != null & order.LastKnowPrice < currentLevel
            : order.LastKnowPrice != null & order.LastKnowPrice > currentLevel;

        if (shouldUpdate)
        {
            _logger.LogInformation($"Starting update of stop level, current price is {currentLevel} and last know price is {order.LastKnowPrice}");
            order.LastKnowPrice = currentLevel;
            _orderDataService.Update(order);
        }
        else
        {
            _logger.LogInformation($"Not updating stop level, current price is {currentLevel} and last know price is {order.LastKnowPrice}");
            return;
        }

                
        var openPosition = await _client.getOTCOpenPositionByDealIdV2(dealId);
        if (openPosition.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error getting the order details for order: {dealId} stopping Trailing Stop");
            UnSubscribeTrailingStop(dealId);
            return;
        }
        
        // var margin = depositBands?.FirstOrDefault(x =>
        //         x.Min < order.Deposit && x.Max > order.Deposit)
        //     ?.Margin ?? 0;

        // var stopLevel = order.LastKnowPrice * (order.ContractSize * openPosition.Response.market.scalingFactor) / margin *
        //                 (order.OrderAction == Enums.orderAction.BUY
        //                     ? 1 - trailingStopDistance
        //                     : 1 + trailingStopDistance) *
        //                 margin / (order.ContractSize * openPosition.Response.market.scalingFactor);
        //
        // var limitLevel = order.LastKnowPrice * (order.ContractSize * openPosition.Response.market.scalingFactor) / margin *
        //                  (order.OrderAction == Enums.orderAction.BUY
        //                      ? 1 + trailingTargetPercent
        //                      : 1 - trailingTargetPercent) *
        //                  margin / (order.ContractSize * openPosition.Response.market.scalingFactor);
        
        // _logger.LogInformation($"Trailing Stop new levels set to StopLevel: {stopLevel} LimitLevel: {limitLevel}");
        
        await _client.editPositionV2(dealId, new EditPositionRequest
        {
            stopLevel = order.LastKnowPrice *
                (order.OrderAction == Enums.orderAction.BUY
                    ? 1 - trailingStopDistance / 10
                    : 1 + trailingStopDistance / 10),
            limitLevel = order.LastKnowPrice *
                         (order.OrderAction == Enums.orderAction.BUY
                             ? 1 - trailingTargetPercent / 10
                             : 1 + trailingTargetPercent / 10),
        });
    }

    public void HandlePricesUpdate(object sender, EventArgs e, string dealId, TradingTargetsDto tradingTarget)
    {
        _logger.LogInformation($"Trailing Stop Price Update for {dealId}");
        var empObj = (RTfeed) sender;
        if (empObj.CurrentLimit.HasValue)
        {
            Start(dealId, empObj.CurrentLimit.Value, tradingTarget.RiskPercent, tradingTarget.TargetPercent);
        }
        else
        {
            _logger.LogError($"Could not start traling stop for deal ID: {dealId}, no Price could be used");
        }
    }

    public async Task SubscribeTrailingStop(TradingTargetsDto tradingTarget, string? dealId)
    {
        if (dealId == null) return;
        _logger.LogInformation($"Starting TrailingStop Subscribe for {dealId}");
        _trailingStopsByDealId.Add(dealId, delegate(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName != "CurrentLimit") return;
                HandlePricesUpdate(sender, e, dealId, tradingTarget);
            }
        );

        _lsClient.PropertyChanged += _trailingStopsByDealId[dealId];
    }

    public void UnSubscribeTrailingStop(string dealId)
    {
        if (_trailingStopsByDealId.TryGetValue(dealId,out var toRemove))
        {
            _lsClient.PropertyChanged -= toRemove;
            _trailingStopsByDealId.Remove(dealId);
        }
    }
}
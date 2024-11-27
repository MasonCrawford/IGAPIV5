using System.Net;
using Common;
using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory.Interfaces;
using IgClient;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.confirms;
using IgClient.Model.dto.endpoint.positions.create.otc.v1;
using IgClient.Model.dto.endpoint.positions.create.otc.v2;
using Microsoft.Extensions.Logging;
using TradingService.Services;

namespace DataFactory;

public class OrderDataService : IOrderDataService
{
    private readonly IIgRestApiClient _client;
    private readonly IOrderService _orderService;

    private readonly ILogger<IOrderDataService> _logger;

    private readonly IEntityRepository<OrdersEntity> _ordersRepository; 

    public OrderDataService(IEntityRepository<OrdersEntity> ordersRepository, ILogger<IOrderDataService> logger,
        IIgRestApiClient client, IOrderService orderService)
    {
        _ordersRepository = ordersRepository;
        _logger = logger;
        _client = client;
        _orderService = orderService;
    }

    public IEnumerable<OrderDto> GetOrdersByTradingTarget(Guid tradingTargetId)
    {
        return _ordersRepository.Get(entity => entity.TradingTargetEntity.Id == tradingTargetId,
            x => x.OrderBy(c => c.CreatedOnUtc)).Select(Map);
    }

    public OrderDto? GetLastClosedOrderByTradingTarget(Guid? tradingTargetId)
    {
        return Map(_ordersRepository
            .Get(orders => orders.TradingTargetEntity.Id == tradingTargetId && orders.Profit != null && orders.LastModifiedOnUtc != null,
                entities => entities.OrderByDescending(x => x.LastModifiedOnUtc)).FirstOrDefault());
    }

    public OrderDto? GetOrderDtoByDealId(string dealId)
    {
        return Map(_ordersRepository.Get(entity => entity.OrderId == dealId).FirstOrDefault());
    }

    public void Update(OrderDto order)
    {
        _ordersRepository.Update(Map(order));
    }
    
    public OrderDto? CreateOrder(TradingTargetsDto tradingTarget)
    {
        var order = new OrderDto();
        var lastOrder = GetLastClosedOrderByTradingTarget(tradingTarget.Id);
        decimal withoutMargin = 0;

        if (lastOrder == null)
        {
            withoutMargin = tradingTarget.InitialDeposit;
            _logger.LogInformation($"No last order found, using the InitialDeposit of :{tradingTarget.InitialDeposit}");
        }
        else
        {
            withoutMargin = lastOrder.Deposit +
                            (lastOrder.Profit!.Value > lastOrder.TargetAmount ? lastOrder.TargetAmount : lastOrder.Profit!.Value <= 0 ?  lastOrder.RiskAmount * -1 : 0);
            _logger.LogInformation($"The last Closed order Profit was: {lastOrder.Profit}");
        }

        if (tradingTarget?.MarginDepositBands == null)
        {
            _logger.LogError($"Can not find MarginDepositBands for tradingTarget: {tradingTarget?.Name??"Unknown"}");
        }
        else
        {
            var withMargin = _orderService.CalMargin(withoutMargin, tradingTarget.MarginDepositBands);
            order.Deposit = withoutMargin;
            order.ContractSize = _orderService.CalContractSize(withMargin);
            order.TargetAmount = _orderService.CalTargetAmount(withMargin, tradingTarget.TargetPercent);
            order.RiskAmount = _orderService.CalRiskAmount(withMargin,tradingTarget.RiskPercent);
            order.TradingTarget = tradingTarget;
        }

        return order;
    }

    public OrderDto? Map(OrdersEntity? entity)
    {
        if (entity == null) return null;
        return new OrderDto
        {
            Id = entity.Id,
            CreatedOnUtc = entity.CreatedOnUtc,
            LastModifiedOnUtc = entity.LastModifiedOnUtc,
            Accepted = entity.Accepted,
            Deposit = entity.Deposit ?? 0,
            Profit = entity.Profit,
            ContractSize = entity.ContractSize ?? 0,
            OrderId = entity.OrderId ?? "",
            RiskAmount = entity.RiskAmount ?? 0,
            TargetAmount = entity.TargetAmount ?? 0,
            OrderAction = entity.OrderAction,
            LastKnowPrice = entity.LastKnowPrice,
            //TradingTarget = _tradingTargetDataService.Map(entity.TradingTargetEntity),
            TransactionReference = entity.TransactionReference ?? ""
        };
    }

    public OrdersEntity? Map(OrderDto? dto)
    {
        if (dto == null) return null;

        return new OrdersEntity
        {
            Id = dto.Id??new Guid(),
            CreatedOnUtc = dto.CreatedOnUtc,
            LastModifiedOnUtc = dto.LastModifiedOnUtc,
            Accepted = dto.Accepted,
            Deposit = dto.Deposit,
            Profit = dto.Profit,
            ContractSize = dto.ContractSize,
            OrderId = dto.OrderId,
            RiskAmount = dto.RiskAmount,
            TargetAmount = dto.TargetAmount,
            OrderAction = dto.OrderAction,
            LastKnowPrice = dto.LastKnowPrice,
            //TradingTargetEntity = _tradingTargetDataService.Map(dto.TradingTarget),
            TransactionReference = dto.TransactionReference
        };
    }

   
}
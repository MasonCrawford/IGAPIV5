using Common;
using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory;
using DataFactory.Interfaces;
using IgClient;
using IgClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace TradeLoop.test;

public class TradingTargetDataServiceTest
{
    private readonly TradingTargetDataService _testee;
    private readonly Mock<IOrderDataService> _orderDataServiceMock = new();
    private readonly Mock<IIgRestApiClient> _clientMock = new();
    private readonly Mock<IEntityRepository<TradingTargetEntity>> _tradingTargetRepositoryMock = new();
    private Mock<IEntityRepository<DepositBandEntity>> _depositBandRepositoryMock = new();

    public TradingTargetDataServiceTest()
    {
        _testee = new TradingTargetDataService(_orderDataServiceMock.Object,
            _clientMock.Object,
            _tradingTargetRepositoryMock.Object,
            _depositBandRepositoryMock.Object,
            Mock.Of<ILogger<TradingTargetDataService>>());
    }

    [Fact]
    public void Test1()
    {
        var target = new TradingTargetsDto
        {
            Id = new Guid(),
            Epic = null,
            Name = null,
            ChartCode = null,
            CurrencyCode = null,
            Status = Enums.status.Active,
            Method = Enums.method.TreeTickSnipe,
            Profit = 0,
            RiskPercent = 0,
            TargetPercent = 0,
            Orders = null,
            InitialDeposit = 2000,
            Expiry = null,
            ScalingFactor = 0,
            MarginDepositBands = null,
            MovingAverageLength = 0,
            TradingLevel = 0
        };
        _orderDataServiceMock.Setup(x => x.CreateOrder(It.IsAny<TradingTargetsDto>())).Returns(new OrderDto
        {
            Id = new Guid(),
            OrderId = "test",
            Accepted = false,
            ContractSize = 10,
            Deposit = 2000,
            RiskAmount = 1,
            TargetAmount = 2,
            TransactionReference = null,
            Profit = null,
            OrderAction = Enums.orderAction.BUY,
            TradingTarget = target
        });

        
        _testee.PlaceOrder(target,
            Enums.orderAction.BUY);
    }
}
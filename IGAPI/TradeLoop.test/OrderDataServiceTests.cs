using System.Linq.Expressions;
using Common;
using Data.Dto;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory;
using DataFactory.Interfaces;
using IgClient.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using TradingService.Services;
using Xunit;
using Xunit.Abstractions;

namespace TradeLoop.test;

public class OrderDataServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrderDataService _testee;
    private readonly Mock<IEntityRepository<OrdersEntity>> _orderRepositoryMock = new();
    private readonly Mock<IIgRestApiClient> clientMock = new();

    public OrderDataServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _testee = new OrderDataService(_orderRepositoryMock.Object, Mock.Of<ILogger<OrderDataService>>(), clientMock.Object,
            new OrderService(Mock.Of<ILogger<OrderService>>()));
    }
    
    [Fact]
    public void Test1()
    {
        // _orderRepositoryMock.Setup(x=>x.Get(It.IsAny<Expression<Func<OrdersEntity, bool>>>()),It.IsAny<Func<IQueryable<OrdersEntity>, IOrderedQueryable<OrdersEntity>>>(),null).Returns();
        
       var results =  _testee.CreateOrder(new TradingTargetsDto
        {
            Id = null,
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
        });
       _testOutputHelper.WriteLine(results.ContractSize.ToString());
       Assert.True(results is {ContractSize: 2000});
    }
    
    
    
}
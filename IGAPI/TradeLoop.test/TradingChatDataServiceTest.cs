using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataFactory;
using IgClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using TradeLoop.Services;
using TradingService.Interfaces;
using TradingService.Services;
using Xunit;

namespace TradeLoop.test;
public class TradingChatDataServiceTest
{
    private readonly TradingChartDataService _testee;
    private readonly Mock<IIgRestApiClient> clientMock = new();
    private readonly Mock<IServiceScopeFactory> serviceScopeFactoryMock = new();
    private readonly Mock<ITradingChartRepository> tradingChartRepositoryMock = new();
    private readonly Mock<IEntityRepository<PricesEntity>> pricesRepositoryMock = new();

    public TradingChatDataServiceTest()
    {
        _testee = new TradingChartDataService( 
            Mock.Of<ILogger<TradingChartDataService>>(),
            clientMock.Object,
            serviceScopeFactoryMock.Object,
            Mock.Of<ITradingChartService>(),
            tradingChartRepositoryMock.Object,
            pricesRepositoryMock.Object);
    }

    [Fact]
    public void Test1()
    {
        
    }

}
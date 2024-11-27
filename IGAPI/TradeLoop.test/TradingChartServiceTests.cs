using Akka.Util.Internal;
using Data.Dto;
using Microsoft.Extensions.Logging;
using Moq;
using TradingService.Services;
using Xunit;

namespace TradeLoop.test;

public class TradingChartServiceTests
{
    private readonly TradingChartService _testee;
    private readonly TradingChartDto _dataUp;
    private readonly TradingChartDto _dataDown;
    public TradingChartServiceTests()
    {
        _testee = new TradingChartService(Mock.Of<ILogger<TradingChartService>>());
        _dataDown = new TradingChartDto
        {
            Id = new Guid(),
            Prices = new List<PricesDto>(){
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                }
            }
            
            },
            ChartCode = null,
        };
        _dataUp = new TradingChartDto
        {
            Id = new Guid(),
            Prices = new List<PricesDto>(){
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 1,
                    Bid = 1,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 2,
                    Bid = 2,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 3,
                    Bid = 3,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 4,
                    Bid = 4,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 5,
                    Bid = 5,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 6,
                    Bid = 6,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 7,
                    Bid = 7,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 8,
                    Bid = 8,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 9,
                    Bid = 9,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 10,
                    Bid = 10,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 11,
                    Bid = 11,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 12,
                    Bid = 12,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 13,
                    Bid = 13,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 14,
                    Bid = 14,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 15,
                    Bid = 15,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 16,
                    Bid = 16,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 17,
                    Bid = 17,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 18,
                    Bid = 18,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 19,
                    Bid = 19,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 20,
                    Bid = 20,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 21,
                    Bid = 21,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 22,
                    Bid = 22,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 23,
                    Bid = 23,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 24,
                    Bid = 24,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 25,
                    Bid = 25,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 26,
                    Bid = 26,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 27,
                    Bid = 27,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 28,
                    Bid = 28,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 29,
                    Bid = 29,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 30,
                    Bid = 30,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 31,
                    Bid = 31,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 32,
                    Bid = 32,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 33,
                    Bid = 33,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 34,
                    Bid = 34,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 35,
                    Bid = 35,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 36,
                    Bid = 36,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 37,
                    Bid = 37,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 38,
                    Bid = 38,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 39,
                    Bid = 39,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 40,
                    Bid = 40,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 41,
                    Bid = 41,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 42,
                    Bid = 42,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 43,
                    Bid = 43,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 44,
                    Bid = 44,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 45,
                    Bid = 45,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 46,
                    Bid = 46,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 47,
                    Bid = 47,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 48,
                    Bid = 48,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 49,
                    Bid = 49,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 50,
                    Bid = 50,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 51,
                    Bid = 51,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 52,
                    Bid = 52,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 53,
                    Bid = 53,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 54,
                    Bid = 54,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 55,
                    Bid = 55,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 56,
                    Bid = 56,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 57,
                    Bid = 57,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 58,
                    Bid = 58,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 59,
                    Bid = 59,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 60,
                    Bid = 60,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 61,
                    Bid = 61,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 62,
                    Bid = 62,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 63,
                    Bid = 63,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 64,
                    Bid = 64,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 65,
                    Bid = 65,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 66,
                    Bid = 66,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 67,
                    Bid = 67,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 68,
                    Bid = 68,
                    LastTraded = null
                }
            },
            new PricesDto
            {
                Id = new Guid(),
                ClosePrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },HighPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },LowPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                },OpenPrice = new PriceDto
                {
                    Id = new Guid(),
                    Ask = 69,
                    Bid = 69,
                    LastTraded = null
                }
            }
            
            },
            ChartCode = null,
        };;
        _dataUp.Prices.Reverse();
    }

    [Fact]
    public void IsMovingDown_withDataUp_shouldBeFalse()
    {

        for (int i = 0; i < _dataUp.Prices.Count; i++)
        {
            _dataUp.Prices[i].MovingAverage = _testee.CalculateMovingAverage(_dataUp.Prices.Skip(i).ToList());
        }
        
        Assert.False( _testee.IsMovingDown(_dataUp));
        
    }

    [Fact]
    public void IsMovingUp_withDataUp_shouldBeTrue()
    {
        for (int i = 0; i < _dataUp.Prices.Count; i++)
        {
            _dataUp.Prices[i].MovingAverage = _testee.CalculateMovingAverage(_dataUp.Prices.Skip(i).ToList());
        }
        
        Assert.True( _testee.IsMovingUp(_dataUp));
    }
    
    [Fact]
    public void IsMovingDown_withDataDown_shouldBeTrue()
    {
        for (int i = 0; i < _dataDown.Prices.Count; i++)
        {
            _dataDown.Prices[i].MovingAverage = _testee.CalculateMovingAverage(_dataDown.Prices.Skip(i).ToList());
        }
        
        Assert.True( _testee.IsMovingDown(_dataDown));
        
    }

    [Fact]
    public void IsMovingUp_withDataDown_shouldBeFalse()
    {
        for (int i = 0; i < _dataDown.Prices.Count; i++)
        {
            _dataDown.Prices[i].MovingAverage = _testee.CalculateMovingAverage(_dataDown.Prices.Skip(i).ToList());
        }
        
        Assert.False( _testee.IsMovingUp(_dataDown));
    }

    [Fact]
    public void IsEngulfingTest()
    {
        
    }

}
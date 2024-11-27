using Data.Dto;
using DataAccess.Entities;

namespace TradingService.Interfaces;

public interface ITradingChartService
{
    public bool IsEngulfing(TradingChartDto chart);
    public bool IsMovingUp(TradingChartDto chart);
    public bool IsMovingDown(TradingChartDto chart);
    decimal? CalculateMovingAverage(TradingChartDto chart);

    decimal? CalculateMovingAverage(List<PricesDto> priceList,
        int numberOfPipesTheMovingAverageIsOver = 50);
}
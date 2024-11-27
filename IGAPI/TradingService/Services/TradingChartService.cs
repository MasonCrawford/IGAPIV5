using Data.Dto;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using TradingService.Interfaces;

namespace TradingService.Services;

public class TradingChartService : ITradingChartService
{
    private readonly ILogger<ITradingChartService> _logger;

    public TradingChartService(ILogger<ITradingChartService> logger)
    {
        _logger = logger;
    }

    public bool IsEngulfing(TradingChartDto chart)
    {
        if (chart?.Prices?.Count < 1) return false;

        if (chart?.Prices?[0].IsRed == chart?.Prices?[1].IsRed)
        {
            _logger.LogInformation("last 1 candles are the same direction");
            return false;
        }

        var isEngulfing = chart?.Prices != null && (!chart.Prices[0].IsRed && chart.Prices[1].IsRed
            ? chart.Prices[0].OpenPrice?.Mid < chart.Prices[1].OpenPrice?.Mid &&
              chart.Prices[0].ClosePrice?.Mid > chart.Prices[1].OpenPrice?.Mid
            : chart.Prices[0].OpenPrice?.Mid > chart.Prices[1].OpenPrice?.Mid &&
              chart.Prices[0].ClosePrice?.Mid < chart.Prices[1].OpenPrice?.Mid);

        _logger.LogInformation($"The last candle was {(isEngulfing ? "" : "not ")}Engulfed");
        return isEngulfing;
    } 
    
    /// <summary>
    ///     calculates the moving average for the given list of Prices
    /// </summary>
    /// <param name="priceList">a list if Prices</param>
    /// <returns>true if the moving average is positive otherwise false </returns>
    public decimal? CalculateMovingAverage(TradingChartDto chart)
    {
        if (chart?.Prices?.Count < 50) return null;

        decimal? result = null;
        result = chart?.Prices?.Take(50).Sum(x => x.ClosePrice?.Mid) / 50;
        _logger.LogInformation($"Current Moving Average is: {result}");
        return result;
    }

    public bool IsMovingUp(TradingChartDto chartEntity)
    {
        if (chartEntity?.Prices?.Count < 10) return false;

        var t = new List<int>();
        for (var i = 1; i < 10; i++)
            t.Add(chartEntity?.Prices?[0].MovingAverage > chartEntity?.Prices?[i].MovingAverage ? 1 : -1);

        var ma = t.Sum() > 0;
        _logger.LogInformation($"the Moving Average is {(ma ? "up" : "down")}");

        return ma;
    }


    public bool IsMovingDown(TradingChartDto chartEntity)
    {
        return !IsMovingUp(chartEntity);
    }


    /// <summary>
    ///     calculates the moving average for the given list of Prices
    /// </summary>
    /// <param name="priceList">a list if Prices</param>
    /// <param name="numberOfPipesTheMovingAverageIsOver">the number of pipes that the moving Average is calculated over </param>
    /// <returns>true if the moving average is positive otherwise false </returns>
    public decimal? CalculateMovingAverage(List<PricesDto> priceList,
        int numberOfPipesTheMovingAverageIsOver = 50)
    {
        decimal? result = null;
        if (priceList.Count > numberOfPipesTheMovingAverageIsOver)
            result = priceList.Take(numberOfPipesTheMovingAverageIsOver).Sum(x => x.ClosePrice?.Mid) /
                     numberOfPipesTheMovingAverageIsOver;

        //Console.WriteLine($" Current Moving Average is {result}");
        return result;
    }
}
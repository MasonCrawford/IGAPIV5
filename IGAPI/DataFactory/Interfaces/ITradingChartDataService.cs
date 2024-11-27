using Data.Dto;
using DataAccess.Entities;

namespace DataFactory.Interfaces;

public interface ITradingChartDataService : IBaseDataScervice<TradingChartEntity, TradingChartDto>
{
    Task<TradingChartDto?> GetFullTradingChart(string? tradingTargetChartCode);
    IEnumerable<string?> ChartCodes();

    Task RemoveOldPrices(int dayToKeep = -1);
    void Update(TradingChartDto tradingChart);
}
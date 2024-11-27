using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class TradingChartEntity : BaseEntity
{
    public string? ChartCode { get; set; }
    public List<PricesEntity>? Prices { get; set; }
}
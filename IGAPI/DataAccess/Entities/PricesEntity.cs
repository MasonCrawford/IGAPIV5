using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class PricesEntity : BaseEntity
{
    /// <Summary>
    ///     Open price
    /// </Summary>
    public PriceEntity? OpenPrice { get; set; }

    /// <Summary>
    ///     Close price
    /// </Summary>
    public PriceEntity? ClosePrice { get; set; }

    /// <Summary>
    ///     High price
    /// </Summary>
    public PriceEntity? HighPrice { get; set; }

    /// <Summary>
    ///     Low price
    /// </Summary>
    public PriceEntity? LowPrice { get; set; }

    /// <summary>
    ///     The Moving Average { get; set; }
    /// </summary>
    public decimal? MovingAverage { get; set; }
}
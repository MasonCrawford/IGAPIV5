using Data.Dto.Common;

namespace Data.Dto;

public class PricesDto : BaseDto
{
    /// <Summary>
    ///     Open price
    /// </Summary>
    public PriceDto? OpenPrice { get; set; }

    /// <Summary>
    ///     Close price
    /// </Summary>
    public PriceDto? ClosePrice { get; set; }

    /// <Summary>
    ///     High price
    /// </Summary>
    public PriceDto? HighPrice { get; set; }

    /// <Summary>
    ///     Low price
    /// </Summary>
    public PriceDto? LowPrice { get; set; }

    /// <summary>
    ///     The Moving Average { get; set; }
    /// </summary>
    public decimal? MovingAverage { get; set; }

    public bool IsRed => OpenPrice?.Mid > ClosePrice?.Mid;
}
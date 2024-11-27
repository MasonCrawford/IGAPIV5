using Data.Dto.Common;

namespace Data.Dto;

public class PriceDto : BaseDto
{
    /// <Summary>
    ///     Bid price
    /// </Summary>
    public decimal? Bid { get; set; }

    /// <Summary>
    ///     Ask price
    /// </Summary>
    public decimal? Ask { get; set; }

    /// <Summary>
    ///     Last traded price.  This will generally be null for non exchange-traded instruments
    /// </Summary>
    public decimal? LastTraded { get; set; }

    /// <summary>
    ///     the Mid price between the asking and biding price
    /// </summary>
    public decimal? Mid => (Ask + Bid) / 2;
}
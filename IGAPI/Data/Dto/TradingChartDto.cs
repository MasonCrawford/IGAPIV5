using Data.Dto.Common;

namespace Data.Dto;

public class TradingChartDto : BaseDto
{
    public string? ChartCode { get; set; }
    public List<PricesDto>? Prices { get; set; }

    public PricesDto? GetRecent => Prices?.Last()??null;
}
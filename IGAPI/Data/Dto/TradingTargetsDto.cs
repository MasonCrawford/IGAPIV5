using Common;
using Data.Dto.Common;

namespace Data.Dto;

public class TradingTargetsDto : BaseDto
{
    public string? Epic { get; set; }
    public string? Name { get; set; }
    public string? ChartCode { get; set; }
    public string? CurrencyCode { get; set; }
    public Enums.status Status { get; set; }
    public Enums.method Method { get; set; }
    public decimal Profit { get; set; }
    public decimal RiskPercent { get; set; }
    public decimal TargetPercent { get; set; }
    public List<OrderDto>? Orders { get; set; }
    public decimal InitialDeposit { get; set; }
    public string? Expiry { get; set; }
    public int ScalingFactor { get; set; }
    public List<DepositBandDto>? MarginDepositBands { get; set; }
    public int MovingAverageLength { get; set; }

    public int TradingLevel { get; set; }
}
using Data.Dto.Common;

namespace Data.Dto;

public class DepositBandDto : BaseDto
{
    public string? Currency { get; set; }
    public decimal? Margin { get; set; }
    public int? Max { get; set; }
    public int? Min { get; set; }
}
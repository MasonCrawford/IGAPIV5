using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class DepositBandEntity : BaseEntity
{
    public string? Currency { get; set; }
    public decimal? Margin { get; set; }
    public int? Max { get; set; }
    public int? Min { get; set; }
}
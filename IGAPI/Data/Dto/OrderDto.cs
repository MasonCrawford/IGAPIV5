using System.Text.Json.Serialization;
using Common;
using Data.Dto.Common;

namespace Data.Dto;

public class OrderDto : BaseDto
{
    public string? OrderId { get; set; }
    public bool Accepted { get; set; }
    public decimal ContractSize { get; set; }
    public decimal Deposit { get; set; }

    public decimal RiskAmount { get; set; }
    public decimal TargetAmount { get; set; }

    public string? TransactionReference { get; set; }
    public decimal? Profit { get; set; }
    
    public decimal? LastKnowPrice { get; set; }
    public Enums.orderAction? OrderAction { get; set; }
    
    public bool IsOpen => !Profit.HasValue;

    [JsonIgnore] public TradingTargetsDto? TradingTarget { get; set; }
}
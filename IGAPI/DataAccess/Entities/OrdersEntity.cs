using Common;
using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class OrdersEntity : BaseEntity
{
    public string? OrderId { get; set; }
    public bool Accepted { get; set; }
    public decimal? ContractSize { get; set; }
    public decimal? Deposit { get; set; }

    public decimal? RiskAmount { get; set; }
    public decimal? TargetAmount { get; set; }

    public string? TransactionReference { get; set; }
    
    public Enums.orderAction? OrderAction { get; set; }
    public decimal? Profit { get; set; }
    public decimal? LastKnowPrice  { get; set; }
    public TradingTargetEntity TradingTargetEntity { get; set; }
}
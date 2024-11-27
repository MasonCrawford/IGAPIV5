using Data.Dto;

namespace TradingService.Services;

public interface IOrderService
{
    decimal CalMargin(decimal withoutMargin, IEnumerable<DepositBandDto> depositBands);
    decimal CalContractSize(decimal withMargin);
    decimal CalTargetAmount(decimal withMargin, decimal targetPercent);
    decimal CalRiskAmount(decimal withMargin, decimal riskPercent);
}
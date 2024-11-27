namespace TradeLoop.Services.Interfaces;

public interface IAccessService
{
    Task<string?> RefreshToken(string? token = null);
}
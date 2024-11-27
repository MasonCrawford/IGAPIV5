namespace DataFactory.Interfaces;

public interface IPricesDataService
{
    void HandlePricesUpdate(object sender, EventArgs e, string chartCode);
}
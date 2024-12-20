namespace IgClient.Model.dto.endpoint.marketdetails.v1;

public class DepositBanding
{
    /// <Summary>
    ///     Boundaries
    /// </Summary>
    public List<string> boundaries { get; set; }

    /// <Summary>
    ///     Margin factor
    /// </Summary>
    public List<string> factors { get; set; }

    /// <Summary>
    ///     Currency
    /// </Summary>
    public string currency { get; set; }
}
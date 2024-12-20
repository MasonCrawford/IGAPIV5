namespace IgClient.Model.dto.endpoint.marketdetails.v1;

public class MarketExpiryData
{
    /// <Summary>
    ///     Last dealing date (GMT)
    /// </Summary>
    public string lastDealingDate { get; set; }

    /// <Summary>
    ///     Settlement information
    /// </Summary>
    public string settlementInfo { get; set; }
}
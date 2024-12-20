namespace IgClient.Model.dto.endpoint.marketdetails.v1;

public class OpeningHours
{
    /// <Summary>
    ///     List of market open and close times (in the account timezone)
    /// </Summary>
    public List<TimeRange> marketTimes { get; set; }
}
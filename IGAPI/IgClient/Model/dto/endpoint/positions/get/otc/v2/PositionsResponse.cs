namespace IgClient.Model.dto.endpoint.positions.get.otc.v2;

public class PositionsResponse
{
    /// <Summary>
    ///     List of positions
    /// </Summary>
    public List<OpenPosition> positions { get; set; }
}
namespace IgClient.Model.dto.endpoint.positions.edit.v1;

public class EditPositionRequest
{
    /// <Summary>
    ///     Stop level
    /// </Summary>
    public decimal? stopLevel { get; set; }

    /// <Summary>
    ///     Limit level
    /// </Summary>
    public decimal? limitLevel { get; set; }
}
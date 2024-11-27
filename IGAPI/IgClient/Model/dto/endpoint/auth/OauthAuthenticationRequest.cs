namespace IgClient.Model.dto.endpoint.auth;

public class OauthAuthenticationRequest
{
    /// <Summary>
    ///     Client login identifier
    /// </Summary>
    public string identifier { get; set; }

    /// <Summary>
    ///     Client login password
    /// </Summary>
    public string password { get; set; }
}
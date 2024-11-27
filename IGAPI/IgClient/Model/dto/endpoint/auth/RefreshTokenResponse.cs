namespace IgClient.Model.dto.endpoint.auth;

public class RefreshTokenResponse
{
    public string access_token { get; set; }
    public string refresh_token { get; set; }
    public string scope { get; set; }
    public string token_type { get; set; }
    public string expires_in { get; set; }
}
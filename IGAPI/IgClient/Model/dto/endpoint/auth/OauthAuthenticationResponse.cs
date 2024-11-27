namespace IgClient.Model.dto.endpoint.auth;

public class OauthToken
{
    public string access_token { get; set; }
    public string refresh_token { get; set; }
    public string scope { get; set; }
    public string token_type { get; set; }
    public string expires_in { get; set; }
}

public class OauthAuthenticationResponse
{
    public string clientId { get; set; }
    public string accountId { get; set; }
    public int timezoneOffset { get; set; }
    public string lightstreamerEndpoint { get; set; }
    public OauthToken oauthToken { get; set; }
}
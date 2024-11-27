namespace IgClient.Model.dto.endpoint.auth;

public class SessionDetailsResponse
{
    public string cst;
    public string xSecurityToken;
    public string clientId { get; set; }
    public string accountId { get; set; }
    public int timezoneOffset { get; set; }
    public string locale { get; set; }
    public string currency { get; set; }
    public string lightstreamerEndpoint { get; set; }
}
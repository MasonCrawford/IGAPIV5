namespace IgClient;

public class ConversationContext
{
    public string accountId;
    public string apiKey;

    public string cst;
    public string oauthToken;
    public string refreshToken;
    public string xSecurityToken;

    public ConversationContext(string cst, string xSecurityToken, string oauthToken, string accountId,
        string apiKey)
    {
        this.cst = cst;
        this.xSecurityToken = xSecurityToken;
        this.oauthToken = oauthToken;
        this.accountId = accountId;
        this.apiKey = apiKey;
    }
}
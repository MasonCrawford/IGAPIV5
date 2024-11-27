using System.Net;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.accountactivity.transaction;
using IgClient.Model.dto.endpoint.auth;
using IgClient.Model.dto.endpoint.confirms;
using IgClient.Model.dto.endpoint.marketdetails.v2;
using IgClient.Model.dto.endpoint.positions.close.v1;
using IgClient.Model.dto.endpoint.positions.create.otc.v1;
using IgClient.Model.dto.endpoint.positions.create.otc.v2;
using IgClient.Model.dto.endpoint.positions.edit.v1;
using IgClient.Model.dto.endpoint.positions.get.otc.v1;
using IgClient.Model.dto.endpoint.prices.v2;
using IgClient.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IgClient;

public class IgRestApiClient : IIgRestApiClient
{
    private readonly IIgRestService _igRestService;
    private readonly ILogger<IgRestApiClient> _logger;
    private ConversationContext _conversationContext;

    public IgRestApiClient(IConfiguration configuration, ILogger<IgRestApiClient> logger, IIgRestService igRestService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _igRestService = igRestService ?? throw new ArgumentNullException(nameof(igRestService));
        //new IgRestService(logger, configuration["ApiEnvironment"]);
        
    }


    private EncryptionKeyResponse ekr { get; set; }

    public ConversationContext GetConversationContext()
    {
        return _conversationContext;
    }

    public async Task<IgResponse<AuthenticationResponse>> SecureAuthenticate(AuthenticationRequest ar,
        string apiKey)
    {
        _conversationContext = new ConversationContext(null, null, null, null, apiKey);
        var encryptedPassword = await SecurePassword(ar.password);

        if (encryptedPassword == ar.password)
            ar.encryptedPassword = false;
        else
            ar.encryptedPassword = true;
        ar.password = encryptedPassword;
        return await authenticate(ar);
    }

    public async Task<IgResponse<OauthAuthenticationResponse>> SecureAuthenticate(OauthAuthenticationRequest ar,
        string apiKey)
    {
        _conversationContext = new ConversationContext(null, null, null, null, apiKey);
        var results = await oauthAuthenticate(ar);
        //todo: add cashing for oauthToken based on time from response
        if (results.StatusCode == HttpStatusCode.OK)
        {
            _conversationContext.oauthToken = results.Response.oauthToken.access_token;
            _conversationContext.refreshToken = results.Response.oauthToken.refresh_token;
            _conversationContext.accountId = results.Response.accountId;
        }

        return results;
    }

    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access.
    ///     <p>
    ///         Please note that region-specific <a href=/ loginrestrictions>login restrictions</a> may apply.
    ///     </p>
    ///     @param authenticationRequest Client login credentials
    ///     @return Client summary account information
    /// </Summary>
    public async Task<IgResponse<AuthenticationResponse>> authenticate(AuthenticationRequest authenticationRequest)
    {
        return await _igRestService.RestfulService<AuthenticationResponse>("/gateway/deal/session", HttpMethod.Post,
            "2", _conversationContext, authenticationRequest);
    }

    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access.
    ///     <p>
    ///         Please note that region-specific <a href=/ loginrestrictions>login restrictions</a> may apply.
    ///     </p>
    ///     @param authenticationRequest Client login credentials
    ///     @return Client summary account information
    /// </Summary>
    public async Task<IgResponse<OauthAuthenticationResponse>> oauthAuthenticate(
        OauthAuthenticationRequest authenticationRequest)
    {
        return await _igRestService.RestfulService<OauthAuthenticationResponse>("/gateway/deal/session",
            HttpMethod.Post, "3", _conversationContext, authenticationRequest);
    } 
    
    /// <summary>
    ///     Refreshes a trading session, obtaining new session tokens for subsequent API access.
    /// </summary>
    /// <param name="refreshTokenRequest">
    ///     The  <see cref="OauthToken.refresh_token" /> found on the
    ///     <see cref="OauthAuthenticationResponse" />
    /// </param>
    /// <returns></returns>
    public async Task<IgResponse<RefreshTokenResponse>> refreshToken(RefreshTokenRequest refreshTokenRequest)
    {
        _conversationContext.oauthToken = null;
        
        var result = await _igRestService.RestfulService<RefreshTokenResponse>(
            "/gateway/deal/session/refresh-token", HttpMethod.Post, "1", _conversationContext, refreshTokenRequest);
        if (result.StatusCode == HttpStatusCode.OK)
        {
            _conversationContext.oauthToken = result.Response.access_token;
            _conversationContext.refreshToken = result.Response.refresh_token;
        }

        return result;
    }

    private async Task refreshToken()
    {
        _logger.LogInformation("Refreshing Token");
        
        await refreshToken(new RefreshTokenRequest
            {refresh_token = _conversationContext.refreshToken});
    }
    
    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access
    ///     @return the encryption key to be used to encode the credentials
    /// </Summary>
    public async Task<IgResponse<EncryptionKeyResponse>> fetchEncryptionKey()
    {
        return await _igRestService.RestfulService<EncryptionKeyResponse>("/gateway/deal/session/encryptionKey",
            HttpMethod.Get, "1", _conversationContext);
    }

    /// <Summary>
    ///     Returns the user's session details and optionally tokens.
    /// </Summary>
    public async Task<IgResponse<SessionDetailsResponse>> fetchSessionDetails(bool fetchSessionTokens = true)
    {
        await refreshToken();

        var result = await _igRestService.RestfulService<SessionDetailsResponse>(
            "/gateway/deal/session?fetchSessionTokens=" + fetchSessionTokens, HttpMethod.Get, "1",
            _conversationContext);
        if (fetchSessionTokens && result.Response != null)
        {
            result.Response.cst = _conversationContext.cst;
            result.Response.xSecurityToken = _conversationContext.xSecurityToken;
        }

        return result;
    }

    /// <Summary>
    ///     Log out of the current session
    /// </Summary>
    public async void logout()
    {
        await _igRestService.RestfulService("/gateway/deal/session", HttpMethod.Delete, "1", _conversationContext);
    }

    /// <Summary>
    ///     Returns all open positions for the active account
    /// </Summary>
    public async Task<IgResponse<PositionsResponse>> getOTCOpenPositionsV2()
    {
        await refreshToken();
        
        return await _igRestService.RestfulService<PositionsResponse>("/gateway/deal/positions", HttpMethod.Get,
            "2", _conversationContext);
    }

    /// <Summary>
    ///     Returns the transaction history for the specified transaction type and period
    ///     @pathParam transactionType Transaction type (( ALL, ALL_DEAL, DEPOSIT, WITHDRAWAL ) )
    ///     @pathParam lastPeriod Interval in milliseconds
    /// </Summary>
    public async Task<IgResponse<TransactionHistoryResponse>> lastTransactionPeriod(string transactionType,
        string lastPeriod)
    {
        await refreshToken();
        
        return await _igRestService.RestfulService<TransactionHistoryResponse>(
            "/gateway/deal/history/transactions?type=" + transactionType + "&maxSpanSeconds=" + lastPeriod,
            HttpMethod.Get, "2",
            _conversationContext);
    }

    /// <Summary>
    ///     Returns the details of the given market
    ///     @pathParam epic The epic of the market to be retrieved
    /// </Summary>
    public async Task<IgResponse<MarketDetailsResponse>> marketDetailsV3(
        string epic)
    {
        await refreshToken();

        return await _igRestService.RestfulService<MarketDetailsResponse>(
            "/gateway/deal/markets/" + epic, HttpMethod.Get, "3", _conversationContext);
    }

    /// <Summary>
    ///     Creates an OTC position
    ///     @param createPositionRequest the request for creating a position
    ///     @return OTC create position response
    /// </Summary>
    public async Task<IgResponse<CreatePositionResponse>> createPositionV2(
        CreatePositionRequest createPositionRequest)
    {
        await refreshToken();

        return await _igRestService.RestfulService<CreatePositionResponse>("/gateway/deal/positions/otc",
            HttpMethod.Post, "2", _conversationContext, createPositionRequest);
    }

    /// <Summary>
    ///     Updates an OTC position
    ///     @pathParam dealId Deal reference identifier
    ///     @param editPositionRequest the request for updating a position
    ///     @return OTC edit position response
    /// </Summary>
    public async Task<IgResponse<EditPositionResponse>> editPositionV2(string dealId,
        EditPositionRequest editPositionRequest)
    {
        await refreshToken();

        return await _igRestService.RestfulService<EditPositionResponse>("/gateway/deal/positions/otc/" + dealId,
            HttpMethod.Put, "2", _conversationContext, editPositionRequest);
    }

    /// <Summary>
    ///     Closes one or more OTC positions
    ///     @param closePositionRequest the request for closing one or more positions
    ///     @return OTC close position response
    /// </Summary>
    public async Task<IgResponse<ClosePositionResponse>> closePosition(ClosePositionRequest closePositionRequest)
    {
        await refreshToken();

        return await _igRestService.RestfulService<ClosePositionResponse>("/gateway/deal/positions/otc",
            HttpMethod.Delete, "1", _conversationContext, closePositionRequest);
    }


    /// <Summary>
    ///     Returns an open position for the active account by deal identifier
    ///     @pathParam dealId Deal reference identifier
    /// </Summary>
    public async Task<IgResponse<OpenPosition>> getOTCOpenPositionByDealIdV2(string dealId)
    {
        await refreshToken();

        return await _igRestService.RestfulService<OpenPosition>("/gateway/deal/positions/" + dealId,
            HttpMethod.Get, "2", _conversationContext);
    }

    /// <Summary>
    ///     Returns a list of historical prices for the given epic, resolution and number of data points
    ///     @pathParam epic Instrument epic
    ///     @pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30,
    ///     HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
    ///     @pathParam numPoints Number of data points required
    /// </Summary>
    public async Task<IgResponse<PriceList>> priceSearchByNumV2(string epic, string resolution, string numPoints)
    {
        await refreshToken();

        return await _igRestService.RestfulService<PriceList>(
            "/gateway/deal/prices/" + epic + "/" + resolution + "/" + numPoints, HttpMethod.Get, "2",
            _conversationContext);
    }

    /// <Summary>
    ///     Returns a deal confirmation for the given deal reference
    ///     @pathParam dealReference Deal reference
    /// </Summary>
    public async Task<IgResponse<ConfirmsResponse>> retrieveConfirm(string dealReference)
    {
        await refreshToken();

        return await _igRestService.RestfulService<ConfirmsResponse>("/gateway/deal/confirms/" + dealReference,
            HttpMethod.Get, "1", _conversationContext);
    }

    /// <Summary>
    ///     Returns the details of the given market
    ///     @pathParam epic The epic of the market to be retrieved
    /// </Summary>
    public async Task<IgResponse<MarketDetailsResponse>> marketDetails(
        string epic)
    {
        await refreshToken();

        return await _igRestService.RestfulService<MarketDetailsResponse>(
            "/gateway/deal/markets/" + epic, HttpMethod.Get, "3", _conversationContext);
    }

    private async Task<string> SecurePassword(string rawPassword)
    {
        var encryptedPassword = rawPassword;


        //Try encrypting password. If we can encrypt it, do so...                                                                            
        var secureResponse = await fetchEncryptionKey();

        ekr = new EncryptionKeyResponse();
        ekr = secureResponse.Response;

        if (ekr != null)
        {
            byte[] encryptedBytes;

            // get a public key to ENCRYPT...
            var rsa = new Rsa(Convert.FromBase64String(ekr.encryptionKey), true);

            encryptedBytes = rsa.RsaEncrypt(string.Format("{0}|{1}", rawPassword, ekr.timeStamp));
            encryptedPassword = Convert.ToBase64String(encryptedBytes);
        }

        return encryptedPassword;
    }
}
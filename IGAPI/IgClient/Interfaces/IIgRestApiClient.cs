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

namespace IgClient.Interfaces;

public interface IIgRestApiClient
{
    ConversationContext GetConversationContext();

    Task<IgResponse<AuthenticationResponse>> SecureAuthenticate(AuthenticationRequest ar,
        string apiKey);

    Task<IgResponse<OauthAuthenticationResponse>> SecureAuthenticate(OauthAuthenticationRequest ar,
        string apiKey);

    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access.
    ///     <p>
    ///         Please note that region-specific <a href=/ loginrestrictions>login restrictions</a> may apply.
    ///     </p>
    ///     @param authenticationRequest Client login credentials
    ///     @return Client summary account information
    /// </Summary>
    Task<IgResponse<AuthenticationResponse>> authenticate(AuthenticationRequest authenticationRequest);

    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access.
    ///     <p>
    ///         Please note that region-specific <a href=/ loginrestrictions>login restrictions</a> may apply.
    ///     </p>
    ///     @param authenticationRequest Client login credentials
    ///     @return Client summary account information
    /// </Summary>
    Task<IgResponse<OauthAuthenticationResponse>> oauthAuthenticate(
        OauthAuthenticationRequest authenticationRequest);

    /// <summary>
    ///     Refreshes a trading session, obtaining new session tokens for subsequent API access.
    /// </summary>
    /// <param name="refreshTokenRequest">
    ///     The  <see cref="OauthToken.refresh_token" /> found on the
    ///     <see cref="OauthAuthenticationResponse" />
    /// </param>
    /// <returns></returns>
    Task<IgResponse<RefreshTokenResponse>> refreshToken(RefreshTokenRequest refreshTokenRequest);

    /// <Summary>
    ///     Creates a trading session, obtaining session tokens for subsequent API access
    ///     @return the encryption key to be used to encode the credentials
    /// </Summary>
    Task<IgResponse<EncryptionKeyResponse>> fetchEncryptionKey();

    /// <Summary>
    ///     Returns the user's session details and optionally tokens.
    /// </Summary>
    Task<IgResponse<SessionDetailsResponse>> fetchSessionDetails(bool fetchSessionTokens = true);

    /// <Summary>
    ///     Log out of the current session
    /// </Summary>
    void logout();


    /// <Summary>
    ///     Returns all open positions for the active account
    /// </Summary>
    Task<IgResponse<PositionsResponse>> getOTCOpenPositionsV2();

    /// <Summary>
    ///     Returns the transaction history for the specified transaction type and period
    ///     @pathParam transactionType Transaction type (( ALL, ALL_DEAL, DEPOSIT, WITHDRAWAL ) )
    ///     @pathParam lastPeriod Interval in milliseconds
    /// </Summary>
    Task<IgResponse<TransactionHistoryResponse>> lastTransactionPeriod(string transactionType,
        string lastPeriod);

    /// <Summary>
    ///     Returns the details of the given market
    ///     @pathParam epic The epic of the market to be retrieved
    /// </Summary>
    Task<IgResponse<MarketDetailsResponse>> marketDetailsV3(
        string epic);

    /// <Summary>
    ///     Creates an OTC position
    ///     @param createPositionRequest the request for creating a position
    ///     @return OTC create position response
    /// </Summary>
    Task<IgResponse<CreatePositionResponse>> createPositionV2(
        CreatePositionRequest createPositionRequest);

    /// <Summary>
    ///     Updates an OTC position
    ///     @pathParam dealId Deal reference identifier
    ///     @param editPositionRequest the request for updating a position
    ///     @return OTC edit position response
    /// </Summary>
    Task<IgResponse<EditPositionResponse>> editPositionV2(string dealId,
        EditPositionRequest editPositionRequest);

    /// <Summary>
    ///     Closes one or more OTC positions
    ///     @param closePositionRequest the request for closing one or more positions
    ///     @return OTC close position response
    /// </Summary>
    Task<IgResponse<ClosePositionResponse>> closePosition(ClosePositionRequest closePositionRequest);

    /// <Summary>
    ///     Returns an open position for the active account by deal identifier
    ///     @pathParam dealId Deal reference identifier
    /// </Summary>
    Task<IgResponse<OpenPosition>> getOTCOpenPositionByDealIdV2(string dealId);

    /// <Summary>
    ///     Returns a list of historical prices for the given epic, resolution and number of data points
    ///     @pathParam epic Instrument epic
    ///     @pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30,
    ///     HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
    ///     @pathParam numPoints Number of data points required
    /// </Summary>
    Task<IgResponse<PriceList>> priceSearchByNumV2(string epic, string resolution, string numPoints);

    /// <Summary>
    ///     Returns a deal confirmation for the given deal reference
    ///     @pathParam dealReference Deal reference
    /// </Summary>
    Task<IgResponse<ConfirmsResponse>> retrieveConfirm(string dealReference);

    /// <Summary>
    ///     Returns the details of the given market
    ///     @pathParam epic The epic of the market to be retrieved
    /// </Summary>
    Task<IgResponse<MarketDetailsResponse>> marketDetails(string epic);
}
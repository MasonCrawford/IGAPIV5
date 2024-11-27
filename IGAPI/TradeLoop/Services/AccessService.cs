using System.Net;
using Common;
using IgClient;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TradeLoop.Services.Interfaces;

namespace TradeLoop.Services;

public class AccessService : IAccessService
{
    private readonly string _ApiKey;
    private readonly IIgRestApiClient _client;
    private readonly ILogger<AccessService> _logger;
    private readonly string _Password;
    private readonly string _UserName;

    public AccessService(IIgRestApiClient igRestApiClient, IConfiguration configuration,
        ILogger<AccessService> logger)
    {
        _client = igRestApiClient;
        _logger = logger;
        _UserName = configuration["UserName"];
        _Password = configuration["Password"];
        _ApiKey = configuration["ApiKey"];
    }

    public async Task<string?> RefreshToken(string? token = null)
    {
        _logger.LogInformation($"Attempting to Refresh Token, token:{token}");
        var refreshTokenRequestAttempts = 0;
        var refreshToken = token != null
            ? new IgResponse<RefreshTokenResponse>
                {StatusCode = HttpStatusCode.OK, Response = new RefreshTokenResponse {refresh_token = token}}
            : null;
        try
        {
            do
            {
                _logger.LogInformation($"Refresh Token Attempt: {refreshTokenRequestAttempts}");

                if (refreshTokenRequestAttempts == 10)
                {
                    _logger.LogError("Refresh Token Request Failed: exceeded refresh Token Request Attempts");
                    //var program = _programService.Get();
                    // program.isActive = false;
                    //_unitOfWork.ProgramRepository.Update(program);
                    return null;
                }
                
                if (refreshToken != null && refreshToken.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _logger.LogError("Refresh Token Attempt failed, Received an Unauthorized response");

                    return null;
                }

                if (refreshToken == null || refreshToken.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogInformation("No Refresh Token available, Attempting login");

                    var authenticationResponse = await _client.SecureAuthenticate(
                        new OauthAuthenticationRequest {identifier = _UserName, password = _Password}, _ApiKey);

                    LoggingUtils.LogWarningIfHttpStatusCodeNotOk(
                        $"Login Attempt was {(authenticationResponse.StatusCode != HttpStatusCode.OK ? "Not" : "")} successful",
                        authenticationResponse.StatusCode, _logger);

                    if (authenticationResponse.StatusCode == HttpStatusCode.OK)
                    {
                        refreshToken = new IgResponse<RefreshTokenResponse>
                        {
                            StatusCode = authenticationResponse.StatusCode, Response = new RefreshTokenResponse
                            {
                                access_token = authenticationResponse.Response.oauthToken.access_token,
                                refresh_token = authenticationResponse.Response.oauthToken.refresh_token
                            }
                        };
                    }
                    else
                    {
                        refreshToken = new IgResponse<RefreshTokenResponse>
                            {StatusCode = authenticationResponse.StatusCode, Response = new RefreshTokenResponse()};
                    }
                }
                else
                {
                    _logger.LogInformation("A Refresh Token was available, Attempting to refreshToken");

                    refreshToken = await _client.refreshToken(new RefreshTokenRequest
                        {refresh_token = refreshToken.Response.refresh_token});
                    LoggingUtils.LogWarningIfHttpStatusCodeNotOk(
                        $"Token Refresh Attempt was {(refreshToken.StatusCode != HttpStatusCode.OK ? "Not " : "")}successful",
                        refreshToken.StatusCode, _logger);
                }

                refreshTokenRequestAttempts++;
         
            } while (refreshToken is not {StatusCode: HttpStatusCode.OK});
        }
        catch (Exception e)
        {
            _logger.LogError($"Refresh Token Request Failed:{e.Message}");
            return null;
        }

        _logger.LogInformation(
            $"Refresh Token Request was successful after {refreshTokenRequestAttempts} attempts");

        return refreshToken.Response.refresh_token;
    }
}
using System.Net;
using IgClient;
using IgClient.Interfaces;
using IgClient.Model.dto.endpoint.auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TradeLoop.Services;
using Xunit;

namespace TradeLoop.test;

public class AccessServiceTests
{
    private readonly AccessService _testee;
    private readonly Mock<IIgRestApiClient> clientMock = new();

    public AccessServiceTests()
    {
        _testee = new AccessService(clientMock.Object, Mock.Of<IConfiguration>(), Mock.Of<ILogger<AccessService>>());
    }

    [Fact]
    public async Task RefreshToken_should_Equal_client_refreshToken_Result_and_not_attempt_auth_when_token_provided()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.OK
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
                {Response = new OauthAuthenticationResponse(), StatusCode = HttpStatusCode.OK});

        var result = await _testee.RefreshToken("working");

        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.Never());

        Assert.True(result.Equals("working1"));
    }

    [Fact]
    public async Task
        RefreshToken_should_Equal_client_SecureAuthenticate_Result_and_attempt_auth_when_no_token_provided()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.OK
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
            {
                Response = new OauthAuthenticationResponse {oauthToken = new OauthToken {refresh_token = "working2"}},
                StatusCode = HttpStatusCode.OK
            });

        var result = await _testee.RefreshToken();

        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.AtLeastOnce());

        Assert.True(result.Equals("working2"));
    }

    [Fact]
    public async Task RefreshToken_should_Equal_NULL_when_Result_is_not_ok()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.InternalServerError
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
                {Response = new OauthAuthenticationResponse(), StatusCode = HttpStatusCode.InternalServerError});
        var result = await _testee.RefreshToken("working");
        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.Exactly(9));

        Assert.Null(result);
    }

    [Fact]
    public async Task RefreshToken_should_Equal_NULL_when_Result_is_not_ok_and_attempt_auth_when_no_token_provided()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.InternalServerError
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
                {Response = new OauthAuthenticationResponse(), StatusCode = HttpStatusCode.InternalServerError});
        var result = await _testee.RefreshToken("working");

        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.Exactly(9));

        Assert.Null(result);
    }

    [Fact]
    public async Task RefreshToken_should_Equal_NULL_when_Result_is_401_and_attempt_auth_1_time()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.BadRequest
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
                {Response = new OauthAuthenticationResponse(), StatusCode = HttpStatusCode.Unauthorized});
        var result = await _testee.RefreshToken("working");

        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.Once());

        Assert.Null(result);
    }

    [Fact]
    public async Task RefreshToken_should_Equal_NULL_when_Result_is_401_and_attempt_auth_1_time_when_no_token_provided()
    {
        clientMock.Setup(x => x.refreshToken(It.IsAny<RefreshTokenRequest>()).Result)
            .Returns(new IgResponse<RefreshTokenResponse>
            {
                Response = new RefreshTokenResponse
                {
                    refresh_token = "working1"
                },
                StatusCode = HttpStatusCode.BadRequest
            });
        clientMock
            .Setup(x => x.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()).Result)
            .Returns(new IgResponse<OauthAuthenticationResponse>
                {Response = new OauthAuthenticationResponse(), StatusCode = HttpStatusCode.Unauthorized});
        var result = await _testee.RefreshToken();

        clientMock.Verify(foo => foo.SecureAuthenticate(It.IsAny<OauthAuthenticationRequest>(), It.IsAny<string>()),
            Times.Once());

        Assert.Null(result);
    }
}
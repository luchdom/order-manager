using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;
using OrderManager.Api.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderManager.Api.Application.Services;

public class TokenService : ITokenService
{
    private readonly ILogger<TokenService> _logger;
    private readonly JwtTokenSettings _jwtTokenSettings;

    public TokenService(ILogger<TokenService> logger, IOptions<JwtTokenSettings> options)
    {
        _logger = logger;
        _jwtTokenSettings = options.Value;
    }

    public string CreateToken(User user)
    {
        _logger.LogInformation("Creating JWT token for user {UserId}", user.Id);
        var expiration = DateTime.UtcNow.AddMinutes(_jwtTokenSettings.ExpirationMinutes);
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();

        _logger.LogInformation("JWT token created for user {UserId}", user.Id);

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
        DateTime expiration) =>
        new(
            _jwtTokenSettings.ValidIssuer,
            _jwtTokenSettings.ValidAudience,
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private List<Claim> CreateClaims(User user)
    {
        try
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email)
            };

            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SigningCredentials CreateSigningCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtTokenSettings.SymmetricSecurityKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}

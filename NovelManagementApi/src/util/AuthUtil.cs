namespace NovelManagementApi.src.util;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetEnv;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.IdentityModel.Tokens;
using NovelManagementApi.src.model.graphql;

public class AuthUtil
{
    public const string USER_ACCOUNT_ID_KEY = "userAccountId";

    // 認証コードからユーザのプロファイル情報を取得
    public static async Task<GoogleJsonWebSignature.Payload> GetGoogleUserProfileFromAuthCode(string authCode)
    {
        try
        {
            // 認証コードからトークン情報を取得する
            var clientSecrets = new ClientSecrets { ClientId = Env.GetString("GOOGLE_AUTH_CLIENT_ID"), ClientSecret = Env.GetString("GOOGLE_AUTH_SECRET") };
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
                Scopes = ["openid", "email", "profile"]
            });
            var token = await flow.ExchangeCodeForTokenAsync(
                "novel_management_user",
                authCode,
                Env.GetString("FRONTEND_DOMAIN"),
                CancellationToken.None);

            // トークン情報を元にアカウントのユーザ情報を取得
            return await GoogleJsonWebSignature.ValidateAsync(token.IdToken, new GoogleJsonWebSignature.ValidationSettings());
        }
        catch (Exception ex)
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage(ex.Message)
                .SetCode(ErrorCode.UNAUTHORIZED.ToString())
                .Build()
            );
        }
    }

    // claimsと期限を渡してjwtトークンを生成
    public static string GenerateJwtToken(Dictionary<string, string> claims, TimeSpan expiresIn)
    {
        var jwtSecret = Env.GetString("JWT_SECRET");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsList = new List<Claim>();
        foreach (var claim in claims)
        {
            claimsList.Add(new Claim(claim.Key, claim.Value?.ToString() ?? string.Empty));
        }

        var token = new JwtSecurityToken(
            claims: claimsList,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.Add(expiresIn)
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    // jwtトークンをデコードしてclaimsを取得
    public static Dictionary<string, string> DecodeJwtToken(string tokenString)
    {
        var jwtSecret = Env.GetString("JWT_SECRET");
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(tokenString, validationParameters, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken ?? throw new SecurityTokenException("Invalid token");

            var claims = new Dictionary<string, string>();
            foreach (var claim in jwtToken.Claims)
            {
                claims[claim.Type] = claim.Value;
            }

            return claims;
        }
        catch (Exception ex)
        {
            throw new GraphQLException(
              ErrorBuilder.New()
             .SetMessage(ex.Message)
             .SetCode(ErrorCode.FORBIDDEN.ToString())
             .Build()
             );
        }
    }

    // ClaimsPrincipalからuserAccountIdを取得
    public static string GetUserAccountIdFromHClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal?.Identity?.IsAuthenticated != true)
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                    .SetMessage("User is not authenticated")
                    .SetCode(ErrorCode.UNAUTHORIZED.ToString())
                    .Build()
            );
        }

        var claims = new Dictionary<string, string>();
        foreach (var claim in claimsPrincipal.Claims)
        {
            claims[claim.Type] = claim.Value;
        }
        if (!claims.TryGetValue(USER_ACCOUNT_ID_KEY, out string? userAccountId))
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                    .SetMessage("Can not get userAccountId")
                    .SetCode(ErrorCode.UNAUTHORIZED.ToString())
                    .Build()
            );
        }

        return userAccountId;
    }
}

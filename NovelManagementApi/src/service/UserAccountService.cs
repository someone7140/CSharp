namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;
using NovelManagementApi.src.util;

public interface IUserAccountService
{
    public Task<string> GetUserAccountRegisterTokenByGoogleAuthCode(string authCode);
}

public class UserAccountService(IUserAccountRepository _userAccountRepository) : IUserAccountService
{

    private readonly IUserAccountRepository userAccountRepository = _userAccountRepository;

    private const string JWT_CLAIM_GMAIL_KEY = "gmail";
    private const string JWT_CLAIM_IMAGE_URL_KEY = "imageUrl";

    public async Task<string> GetUserAccountRegisterTokenByGoogleAuthCode(string authCode)
    {
        var profile = await AuthUtil.GetGoogleUserProfileFromAuthCode(authCode);
        // すでにgmailが登録されていたらエラー
        var userAccountEntity = userAccountRepository.GetUserAccountByGmail(profile.Email);
        if (userAccountEntity is not null)
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Already registered gmail")
                .SetCode(ErrorCode.FORBIDDEN.ToString())
                .Build()
            );
        }

        var claims = new Dictionary<string, string>
        {
          { JWT_CLAIM_GMAIL_KEY, profile.Email },
          { JWT_CLAIM_IMAGE_URL_KEY, profile.Picture }
        };
        return AuthUtil.GenerateJwtToken(claims, TimeSpan.FromHours(4));
    }
}

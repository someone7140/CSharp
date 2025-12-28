namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;
using NovelManagementApi.src.util;

public interface IUserAccountService
{
    public Task<string> GetUserAccountRegisterTokenByGoogleAuthCode(string authCode);
    public Task<UserAccountResponse> GetUserAccountByGoogleAuthCode(string authCode);
    public UserAccountResponse AddUserAccount(string registerToken, string userSettingId, string name);
    public UserAccountResponse GetUserAccountByUserAccountId(string userAccountId);
}

public class UserAccountService(IUserAccountRepository _userAccountRepository) : IUserAccountService
{

    private readonly IUserAccountRepository userAccountRepository = _userAccountRepository;

    private const string JWT_CLAIM_GMAIL_KEY = "gmail";
    private const string JWT_CLAIM_IMAGE_URL_KEY = "imageUrl";

    // 認証コードからユーザ登録用のトークンを取得
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

    // 認証コードからユーザ情報を取得
    public async Task<UserAccountResponse> GetUserAccountByGoogleAuthCode(string authCode)
    {
        var profile = await AuthUtil.GetGoogleUserProfileFromAuthCode(authCode);
        var userAccountEntity = userAccountRepository.GetUserAccountByGmail(profile.Email) ?? throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Can not find user")
                .SetCode(ErrorCode.NOT_FOUND.ToString())
                .Build()
            );
        var idClaims = new Dictionary<string, string>
        {
          { AuthUtil.USER_ACCOUNT_ID_KEY, userAccountEntity.Id }
        };

        return new UserAccountResponse()
        {
            Token = AuthUtil.GenerateJwtToken(idClaims, TimeSpan.FromDays(120)),
            UserSettingId = userAccountEntity.UserSettingId,
            Name = userAccountEntity.Name,
            ImageUrl = userAccountEntity.ImageUrl
        };
    }

    // ユーザの新規登録
    public UserAccountResponse AddUserAccount(string registerToken, string userSettingId, string name)
    {
        var claims = AuthUtil.DecodeJwtToken(registerToken);
        var gmail = claims[JWT_CLAIM_GMAIL_KEY];
        var imageUrl = claims[JWT_CLAIM_IMAGE_URL_KEY];

        // すでにgmailが登録されていたらエラー
        var userAccountEntity = userAccountRepository.GetUserAccountByGmail(gmail);
        if (userAccountEntity is not null)
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Already registered gmail")
                .SetCode(ErrorCode.FORBIDDEN.ToString())
                .Build()
            );
        }

        // すでにuserSettingIdが登録されていたらエラー
        userAccountEntity = userAccountRepository.GetUserAccountByUserSettingId(userSettingId);
        if (userAccountEntity is not null)
        {
            throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Already registered userSettingId")
                .SetCode(ErrorCode.FORBIDDEN.ToString())
                .Build()
            );
        }

        // ユーザーを登録
        var id = Guid.CreateVersion7().ToString();
        userAccountRepository.AddUserAccountEntity(
            id,
            name,
            gmail,
            userSettingId,
            imageUrl
        );

        var idClaims = new Dictionary<string, string>
        {
          { AuthUtil.USER_ACCOUNT_ID_KEY, id }
        };
        return new UserAccountResponse()
        {
            Token = AuthUtil.GenerateJwtToken(idClaims, TimeSpan.FromDays(120)),
            UserSettingId = userSettingId,
            Name = name,
            ImageUrl = imageUrl
        };
    }


    // ユーザのIDでアカウント情報を取得
    public UserAccountResponse GetUserAccountByUserAccountId(string userAccountId)
    {
        var userAccountEntity = userAccountRepository.GetUserAccountByUserUserAccountId(userAccountId) ?? throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Can not find user")
                .SetCode(ErrorCode.NOT_FOUND.ToString())
                .Build()
            );

        return new UserAccountResponse()
        {
            Token = null,
            UserSettingId = userAccountEntity.UserSettingId,
            Name = userAccountEntity.Name,
            ImageUrl = userAccountEntity.ImageUrl
        };
    }
}

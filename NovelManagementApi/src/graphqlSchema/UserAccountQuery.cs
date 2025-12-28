namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Query")]
public class UserAccountQuery
{

    public async Task<string> GetUserAccountRegisterTokenFromGoogleAuthCode(
        string authCode,
        [Service] IUserAccountService userAccountService)
    {
        return await userAccountService.GetUserAccountRegisterTokenByGoogleAuthCode(authCode);
    }

    [Authorize]
    public UserAccountResponse UserAccountResponseGetUserAccountFromAuthHeader(
        ClaimsPrincipal claimsPrincipal,
        [Service] IUserAccountService userAccountService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return userAccountService.GetUserAccountByUserAccountId(userAccountId);
    }
}

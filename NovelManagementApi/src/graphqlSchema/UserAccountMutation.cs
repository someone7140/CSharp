namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Mutation")]
public class UserAccountMutation
{
    public UserAccountResponse AddUserAccountByGoogleAuth(
        string registerToken,
        string userSettingId,
        string name,
        [Service] IUserAccountService userAccountService)
    {
        return userAccountService.AddUserAccount(registerToken, userSettingId, name);
    }

    public async Task<UserAccountResponse> LoginByGoogleAuth(
        string authCode,
        [Service] IUserAccountService userAccountService)
    {
        return await userAccountService.GetUserAccountByGoogleAuthCode(authCode);
    }

    [Authorize]
    public async Task<UserAccountResponse> EditUserAccount(
        string userSettingId,
        string name,
        ClaimsPrincipal claimsPrincipal,
        [Service] IUserAccountService userAccountService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return userAccountService.EditUserAccount(userSettingId, name, userAccountId);
    }

}

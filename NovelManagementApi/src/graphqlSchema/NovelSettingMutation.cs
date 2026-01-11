namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Mutation")]
public class NovelSettingMutation
{
    [Authorize]
    public bool RegisterNovelSettings(
        NovelSettingRegisterRequest[] inputs,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelSettingService novelSettingService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelSettingService.RegisterNovelSettings(inputs, userAccountId);
    }

    [Authorize]
    public bool DeleteNovelSettingById(
    string id,
    ClaimsPrincipal claimsPrincipal,
    [Service] INovelSettingService novelSettingService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelSettingService.DeleteNovelSettingById(id, userAccountId);
    }

    [Authorize]
    public bool DeleteNovelSettingByIds(
        string[] ids,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelSettingService novelSettingService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelSettingService.DeleteNovelSettingByIds(ids, userAccountId);
    }
}

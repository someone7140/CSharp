namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Query")]
public class NovelSettingQuery
{
    [Authorize]
    public List<NovelSettingResponse> GetNovelSettingsByNovelId(
        string novelId,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelSettingService novelSettingService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelSettingService.GetNovelSettingsByNovelId(novelId, userAccountId);
    }

    [Authorize]
    public List<NovelSettingResponse> GetNovelSettingsByParentSettingId(
        string parentSettingId,
        ClaimsPrincipal claimsPrincipal,
    [Service] INovelSettingService novelSettingService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelSettingService.GetNovelSettingsByParentSettingId(parentSettingId, userAccountId);
    }
}

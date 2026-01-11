namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Query")]
public class NovelContentsQuery
{
    [Authorize]
    public List<NovelContentsResponse> GetNovelContentsByNovelId(
        string novelId,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelContentsService novelContentsService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelContentsService.GetNovelContentsByNovelId(novelId, userAccountId);
    }

}

namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Query")]
public class NovelQuery
{
    [Authorize]
    public List<NovelResponse> GetMyNovels(
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelService novelService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelService.GetNovelsByUserAccountId(userAccountId);
    }
}

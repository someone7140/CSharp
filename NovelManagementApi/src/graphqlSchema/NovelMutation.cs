namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Mutation")]
public class NovelMutation
{
    [Authorize]
    public bool AddNovel(
        string title,
        string? description,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelService novelService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelService.AddNovel(title, description, userAccountId);
    }

    [Authorize]
    public bool EditNovel(
        string id,
        string title,
        string? description,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelService novelService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelService.EditNovel(id, title, description, userAccountId);
    }

    [Authorize]
    public bool DeleteNovel(
        string id,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelService novelService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelService.DeleteNovel(id, userAccountId);
    }
}

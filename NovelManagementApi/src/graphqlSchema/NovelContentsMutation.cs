namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Mutation")]
public class NovelContentsMutation
{
    [Authorize]
    public bool RegisterNovelContents(
        NovelContentsRegisterRequest[] inputs,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelContentsService novelContentsService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelContentsService.RegisterNovelContents(inputs, userAccountId);
    }


    [Authorize]
    public bool DeleteNovelContentsById(
    string id,
    ClaimsPrincipal claimsPrincipal,
    [Service] INovelContentsService novelContentsService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelContentsService.DeleteNovelContentsById(id, userAccountId);
    }

    [Authorize]
    public bool DeleteNovelContentsByIds(
        string[] ids,
        ClaimsPrincipal claimsPrincipal,
        [Service] INovelContentsService novelContentsService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return novelContentsService.DeleteNovelContentsByIds(ids, userAccountId);
    }
}

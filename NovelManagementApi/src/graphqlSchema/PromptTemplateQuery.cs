namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Query")]
public class PromptTemplateQuery
{
    [Authorize]
    public PromptTemplateResponse GetPromptTemplateById(
        string templateId,
        ClaimsPrincipal claimsPrincipal,
        [Service] IPromptTemplateService promptTemplateService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return promptTemplateService.GetPromptTemplateById(templateId, userAccountId);
    }

    [Authorize]
    public List<PromptTemplateResponse> GetPromptTemplates(
        ClaimsPrincipal claimsPrincipal,
        [Service] IPromptTemplateService promptTemplateService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return promptTemplateService.GetPromptTemplates(userAccountId);
    }
}

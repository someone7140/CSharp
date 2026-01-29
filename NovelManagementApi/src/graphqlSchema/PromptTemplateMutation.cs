namespace NovelManagementApi.src.graphqlSchema;

using System.Security.Claims;
using HotChocolate.Authorization;
using NovelManagementApi.src.service;
using NovelManagementApi.src.util;

[ExtendObjectType("Mutation")]
public class PromptTemplateMutation
{
    [Authorize]
    public bool AddPromptTemplate(
        string name,
        int? displayOrder,
        string? template,
        string? description,
        ClaimsPrincipal claimsPrincipal,
        [Service] IPromptTemplateService promptTemplateService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return promptTemplateService.AddPromptTemplate(name, displayOrder, template, description, userAccountId);
    }

    [Authorize]
    public bool EditPromptTemplate(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        ClaimsPrincipal claimsPrincipal,
        [Service] IPromptTemplateService promptTemplateService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return promptTemplateService.EditPromptTemplate(id, name, displayOrder, template, description, userAccountId);
    }

    [Authorize]
    public bool DeletePromptTemplate(
        string id,
        ClaimsPrincipal claimsPrincipal,
    [Service] IPromptTemplateService promptTemplateService)
    {
        var userAccountId = AuthUtil.GetUserAccountIdFromHClaimsPrincipal(claimsPrincipal);
        return promptTemplateService.DeletePromptTemplate(id, userAccountId);
    }

}

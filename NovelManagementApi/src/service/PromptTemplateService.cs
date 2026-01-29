namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;

public interface IPromptTemplateService
{
    public bool AddPromptTemplate(
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    );
    public bool EditPromptTemplate(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    );
    public bool DeletePromptTemplate(string id, string userAccountId);
    public PromptTemplateResponse GetPromptTemplateById(string id, string userAccountId);
    public List<PromptTemplateResponse> GetPromptTemplates(string userAccountId);
}

public class PromptTemplateService(
    IPromptTemplateRepository _promptTemplateRepository,
    INovelRepository _novelRepository
) : IPromptTemplateService
{

    private readonly IPromptTemplateRepository promptTemplateRepository = _promptTemplateRepository;
    private readonly INovelRepository novelRepository = _novelRepository;

    // テンプレートの新規登録
    public bool AddPromptTemplate(
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    )
    {
        var id = Guid.CreateVersion7().ToString();
        promptTemplateRepository.AddPromptTemplateEntity(id, name, displayOrder, template, description, userAccountId);
        return true;
    }

    // テンプレートの編集
    public bool EditPromptTemplate(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    )
    {
        promptTemplateRepository.EditPromptTemplateEntity(id, name, displayOrder, template, description, userAccountId);
        return true;
    }

    // テンプレートの削除
    public bool DeletePromptTemplate(string id, string userAccountId)
    {
        promptTemplateRepository.DeletePromptTemplateEntity(id, userAccountId);
        return true;
    }

    // テンプレートのID指定取得
    public PromptTemplateResponse GetPromptTemplateById(string id, string userAccountId)
    {
        var entity = promptTemplateRepository.GetPromptTemplateById(id, userAccountId) ?? throw new GraphQLException(
                ErrorBuilder.New()
                .SetMessage("Can not find template")
                .SetCode(ErrorCode.NOT_FOUND.ToString())
                .Build()
            );

        return new PromptTemplateResponse()
        {
            Id = entity.Id,
            Name = entity.Name,
            DisplayOrder = entity.DisplayOrder,
            Template = entity.Template,
            Description = entity.Description
        };
    }

    // テンプレートのリスト取得
    public List<PromptTemplateResponse> GetPromptTemplates(string userAccountId)
    {
        var entities = promptTemplateRepository.GetPromptTemplates(userAccountId);

        return entities.Select(entity => new PromptTemplateResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            DisplayOrder = entity.DisplayOrder,
            Template = entity.Template,
            Description = entity.Description
        }).ToList();
    }

}

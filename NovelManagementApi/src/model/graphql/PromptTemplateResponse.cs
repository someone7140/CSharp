namespace NovelManagementApi.src.model.graphql;

public class PromptTemplateResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public int? DisplayOrder { get; set; }
    public string? Template { get; set; }
    public string? Description { get; set; }
}

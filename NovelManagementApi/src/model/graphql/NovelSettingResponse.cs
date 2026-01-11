namespace NovelManagementApi.src.model.graphql;


public class NovelSettingResponse
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string NovelId { get; set; }

    public string? ParentSettingId { get; set; }

    public int? DisplayOrder { get; set; }

    public required string[] Attributes { get; set; }

    public string? Description { get; set; }

}

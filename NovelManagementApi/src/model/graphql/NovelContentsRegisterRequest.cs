namespace NovelManagementApi.src.model.graphql;


public class NovelContentsRegisterRequest
{
    public string? Id { get; set; }

    public required string ChapterName { get; set; }

    public required string NovelId { get; set; }

    public string? ParentContentsId { get; set; }

    public string? Contents { get; set; }

    public int? DisplayOrder { get; set; }

    public string? Description { get; set; }

}

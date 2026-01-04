namespace NovelManagementApi.src.model.graphql;


public class NovelResponse
{
    public required string Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

}

namespace NovelManagementApi.src.model.graphql;


public class UserAccountResponse
{
    public required string Token { get; set; }

    public required string UserSettingId { get; set; }

    public required string Name { get; set; }

    public string? ImageUrl { get; set; }
}

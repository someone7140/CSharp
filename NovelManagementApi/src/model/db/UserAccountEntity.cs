namespace NovelManagementApi.src.model.db;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("user_accounts")]
[Index(nameof(Gmail), IsUnique = true), Index(nameof(UserSettingId))]
public class UserAccountEntity
{
    [Key]
    [Column("id", TypeName = "varchar")]
    public required string Id { get; set; }

    [Column("user_setting_id", TypeName = "varchar")]
    public required string UserSettingId { get; set; }

    [Column("name", TypeName = "varchar")]
    public required string Name { get; set; }

    [Column("gmail", TypeName = "varchar")]
    public required string Gmail { get; set; }

    [Column("image_url", TypeName = "varchar")]
    public string? ImageUrl { get; set; }

    [Column("created_at", TypeName = "timestamptz")]
    public required DateTimeOffset CreatedAt { get; set; }
}

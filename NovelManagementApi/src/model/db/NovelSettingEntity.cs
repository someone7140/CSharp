namespace NovelManagementApi.src.model.db;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("novel_settings")]
[Index(nameof(OwnerUserAccountId)), Index(nameof(NovelId))]
public class NovelSettingEntity
{
    [Key]
    [Column("id", TypeName = "varchar")]
    public required string Id { get; set; }

    [Column("name", TypeName = "varchar")]
    public required string Name { get; set; }

    [Column("novel_id", TypeName = "varchar")]
    public required string NovelId { get; set; }

    [Column("owner_user_account_id", TypeName = "varchar")]
    public required string OwnerUserAccountId { get; set; }

    [Column("parent_setting_id", TypeName = "varchar")]
    public string? ParentSettingId { get; set; }

    [Column("display_order", TypeName = "int4")]
    public int? DisplayOrder { get; set; }

    [Column("attributes", TypeName = "text[]")]
    public required string[] Attributes { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }
}

namespace NovelManagementApi.src.model.db;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("novel_contents")]
[Index(nameof(OwnerUserAccountId)), Index(nameof(NovelId))]
public class NovelContentsEntity
{
    [Key]
    [Column("id", TypeName = "varchar")]
    public required string Id { get; set; }

    [Column("chapter_name", TypeName = "varchar")]
    public required string ChapterName { get; set; }

    [Column("novel_id", TypeName = "varchar")]
    public required string NovelId { get; set; }

    [Column("owner_user_account_id", TypeName = "varchar")]
    public required string OwnerUserAccountId { get; set; }

    [Column("parent_contents_id", TypeName = "varchar")]
    public string? ParentContentsId { get; set; }

    [Column("contents", TypeName = "text")]
    public string? Contents { get; set; }

    [Column("display_order", TypeName = "int4")]
    public int? DisplayOrder { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

}

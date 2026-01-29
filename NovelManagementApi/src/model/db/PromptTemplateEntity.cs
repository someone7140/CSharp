namespace NovelManagementApi.src.model.db;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("prompt_templates")]
[Index(nameof(OwnerUserAccountId))]
public class PromptTemplateEntity
{
    [Key]
    [Column("id", TypeName = "varchar")]
    public required string Id { get; set; }

    [Column("name", TypeName = "varchar")]
    public required string Name { get; set; }

    [Column("owner_user_account_id", TypeName = "varchar")]
    public required string OwnerUserAccountId { get; set; }

    [Column("display_order", TypeName = "int4")]
    public int? DisplayOrder { get; set; }

    [Column("template", TypeName = "text")]
    public string? Template { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

}

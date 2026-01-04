namespace NovelManagementApi.src.model.db;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("novels")]
[Index(nameof(OwnerUserAccountId))]
public class NovelEntity
{
    [Key]
    [Column("id", TypeName = "varchar")]
    public required string Id { get; set; }

    [Column("title", TypeName = "varchar")]
    public required string Title { get; set; }

    [Column("description", TypeName = "varchar")]
    public string? Description { get; set; }

    [Column("owner_user_account_id", TypeName = "varchar")]
    public required string OwnerUserAccountId { get; set; }

    [Column("created_at", TypeName = "timestamptz")]
    public required DateTimeOffset CreatedAt { get; set; }
}

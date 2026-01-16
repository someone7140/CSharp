using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "novel_contents",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar", nullable: false),
                    chapter_name = table.Column<string>(type: "varchar", nullable: false),
                    novel_id = table.Column<string>(type: "varchar", nullable: false),
                    owner_user_account_id = table.Column<string>(type: "varchar", nullable: false),
                    parent_contents_id = table.Column<string>(type: "varchar", nullable: true),
                    contents = table.Column<string>(type: "text", nullable: true),
                    display_order = table.Column<int>(type: "int4", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_novel_contents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "novel_settings",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    novel_id = table.Column<string>(type: "varchar", nullable: false),
                    owner_user_account_id = table.Column<string>(type: "varchar", nullable: false),
                    parent_setting_id = table.Column<string>(type: "varchar", nullable: true),
                    display_order = table.Column<int>(type: "int4", nullable: true),
                    attributes = table.Column<string[]>(type: "text[]", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_novel_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "novels",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar", nullable: false),
                    title = table.Column<string>(type: "varchar", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    owner_user_account_id = table.Column<string>(type: "varchar", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_novels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_accounts",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar", nullable: false),
                    user_setting_id = table.Column<string>(type: "varchar", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    gmail = table.Column<string>(type: "varchar", nullable: false),
                    image_url = table.Column<string>(type: "varchar", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_accounts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_novel_contents_novel_id",
                table: "novel_contents",
                column: "novel_id");

            migrationBuilder.CreateIndex(
                name: "IX_novel_contents_owner_user_account_id",
                table: "novel_contents",
                column: "owner_user_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_novel_settings_novel_id",
                table: "novel_settings",
                column: "novel_id");

            migrationBuilder.CreateIndex(
                name: "IX_novel_settings_owner_user_account_id",
                table: "novel_settings",
                column: "owner_user_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_novels_owner_user_account_id",
                table: "novels",
                column: "owner_user_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_accounts_gmail",
                table: "user_accounts",
                column: "gmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_accounts_user_setting_id",
                table: "user_accounts",
                column: "user_setting_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "novel_contents");

            migrationBuilder.DropTable(
                name: "novel_settings");

            migrationBuilder.DropTable(
                name: "novels");

            migrationBuilder.DropTable(
                name: "user_accounts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeopardy.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_classifications_clue_id",
                table: "classifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classifications",
                table: "classifications",
                columns: new[] { "clue_id", "category_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_classifications",
                table: "classifications");

            migrationBuilder.CreateIndex(
                name: "IX_classifications_clue_id",
                table: "classifications",
                column: "clue_id");
        }
    }
}

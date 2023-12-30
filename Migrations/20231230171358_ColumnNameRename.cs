using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeopardyAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clues_airdates_Game",
                table: "clues");

            migrationBuilder.RenameColumn(
                name: "Clue",
                table: "documents",
                newName: "clue");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "documents",
                newName: "answer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "documents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "clues",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "clues",
                newName: "round");

            migrationBuilder.RenameColumn(
                name: "Game",
                table: "clues",
                newName: "game");

            migrationBuilder.RenameIndex(
                name: "IX_clues_Game",
                table: "clues",
                newName: "IX_clues_game");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_clues_airdates_game",
                table: "clues",
                column: "game",
                principalTable: "airdates",
                principalColumn: "game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clues_airdates_game",
                table: "clues");

            migrationBuilder.RenameColumn(
                name: "clue",
                table: "documents",
                newName: "Clue");

            migrationBuilder.RenameColumn(
                name: "answer",
                table: "documents",
                newName: "Answer");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "documents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "clues",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "round",
                table: "clues",
                newName: "Round");

            migrationBuilder.RenameColumn(
                name: "game",
                table: "clues",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_clues_game",
                table: "clues",
                newName: "IX_clues_Game");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_clues_airdates_Game",
                table: "clues",
                column: "Game",
                principalTable: "airdates",
                principalColumn: "game");
        }
    }
}

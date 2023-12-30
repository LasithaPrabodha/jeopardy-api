using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeopardyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airdates",
                columns: table => new
                {
                    game = table.Column<int>(type: "int", nullable: false),
                    airdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airdates", x => x.game);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clues",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<int>(type: "int", nullable: true),
                    Round = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clues", x => x.id);
                    table.ForeignKey(
                        name: "FK_clues_airdates_Game",
                        column: x => x.Game,
                        principalTable: "airdates",
                        principalColumn: "game");
                    table.ForeignKey(
                        name: "FK_clues_documents_id",
                        column: x => x.id,
                        principalTable: "documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    clue_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_classifications_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_classifications_clues_clue_id",
                        column: x => x.clue_id,
                        principalTable: "clues",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_category",
                table: "categories",
                column: "category",
                unique: true,
                filter: "[category] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_classifications_category_id",
                table: "classifications",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_classifications_clue_id",
                table: "classifications",
                column: "clue_id");

            migrationBuilder.CreateIndex(
                name: "IX_clues_Game",
                table: "clues",
                column: "Game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classifications");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "clues");

            migrationBuilder.DropTable(
                name: "airdates");

            migrationBuilder.DropTable(
                name: "documents");
        }
    }
}

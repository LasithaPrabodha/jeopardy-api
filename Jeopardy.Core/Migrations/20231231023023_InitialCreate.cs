using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeopardy.Core.Migrations
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
                    game = table.Column<int>(type: "INTEGER", nullable: false),
                    airdate = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airdates", x => x.game);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clue = table.Column<string>(type: "TEXT", nullable: true),
                    answer = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clues",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    game = table.Column<int>(type: "INTEGER", nullable: false),
                    round = table.Column<int>(type: "INTEGER", nullable: false),
                    value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clues", x => x.id);
                    table.ForeignKey(
                        name: "FK_clues_airdates_game",
                        column: x => x.game,
                        principalTable: "airdates",
                        principalColumn: "game",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clues_documents_id",
                        column: x => x.id,
                        principalTable: "documents",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    clue_id = table.Column<int>(type: "INTEGER", nullable: false),
                    category_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_classifications_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classifications_clues_clue_id",
                        column: x => x.clue_id,
                        principalTable: "clues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_category",
                table: "categories",
                column: "category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_classifications_category_id",
                table: "classifications",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_classifications_clue_id",
                table: "classifications",
                column: "clue_id");

            migrationBuilder.CreateIndex(
                name: "IX_clues_game",
                table: "clues",
                column: "game");
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

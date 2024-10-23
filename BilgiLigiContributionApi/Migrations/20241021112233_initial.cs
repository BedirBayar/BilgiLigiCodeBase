using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgiLigiContributionApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionDifficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    DifficultyPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDifficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDraft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    ArchivedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDraft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionQuality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QualityPoint = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserContributionRating",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContributionRating", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDraftDifficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDraftId = table.Column<int>(type: "int", nullable: false),
                    DifficultyPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDraftDifficulty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionDraftDifficulty_QuestionDraft_QuestionDraftId",
                        column: x => x.QuestionDraftId,
                        principalTable: "QuestionDraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDraftQuality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDraftId = table.Column<int>(type: "int", nullable: false),
                    QualityPoint = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDraftQuality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionDraftQuality_QuestionDraft_QuestionDraftId",
                        column: x => x.QuestionDraftId,
                        principalTable: "QuestionDraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDraftDifficulty_QuestionDraftId",
                table: "QuestionDraftDifficulty",
                column: "QuestionDraftId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDraftQuality_QuestionDraftId",
                table: "QuestionDraftQuality",
                column: "QuestionDraftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionDifficulty");

            migrationBuilder.DropTable(
                name: "QuestionDraftDifficulty");

            migrationBuilder.DropTable(
                name: "QuestionDraftQuality");

            migrationBuilder.DropTable(
                name: "QuestionQuality");

            migrationBuilder.DropTable(
                name: "UserContributionRating");

            migrationBuilder.DropTable(
                name: "QuestionDraft");
        }
    }
}

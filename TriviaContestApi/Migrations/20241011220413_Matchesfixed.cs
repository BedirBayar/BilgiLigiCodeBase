using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaContestApi.Migrations
{
    /// <inheritdoc />
    public partial class Matchesfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderBoardUser_LeaderBoards_LeaderBoardId",
                table: "LeaderBoardUser");

            migrationBuilder.DropTable(
                name: "MatchQuestions");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderBoardUser",
                table: "LeaderBoardUser");

            migrationBuilder.RenameTable(
                name: "LeaderBoardUser",
                newName: "LeaderBoardUsers");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderBoardUser_LeaderBoardId",
                table: "LeaderBoardUsers",
                newName: "IX_LeaderBoardUsers_LeaderBoardId");

            migrationBuilder.AddColumn<int>(
                name: "AwardId",
                table: "Contests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContestantNumber",
                table: "Contests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPeriodic",
                table: "Contests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "Contests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MatchFrequency",
                table: "Contests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PeriodType",
                table: "Contests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaderBoardUsers",
                table: "LeaderBoardUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TeamMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1Id = table.Column<int>(type: "int", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Id = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    ArchivedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTeamMatch = table.Column<bool>(type: "bit", nullable: false),
                    IsLeagueMatch = table.Column<bool>(type: "bit", nullable: false),
                    ContestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMatches_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User1Score = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false),
                    User2Score = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    ArchivedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTeamMatch = table.Column<bool>(type: "bit", nullable: false),
                    IsLeagueMatch = table.Column<bool>(type: "bit", nullable: false),
                    ContestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMatches_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMatchQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMatchQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMatchQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchQuestions_TeamMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "TeamMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMatchQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatchQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMatchQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMatchQuestions_UserMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "UserMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatches_ContestId",
                table: "TeamMatches",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchQuestions_MatchId",
                table: "TeamMatchQuestions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchQuestions_QuestionId",
                table: "TeamMatchQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatches_ContestId",
                table: "UserMatches",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchQuestions_MatchId",
                table: "UserMatchQuestions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchQuestions_QuestionId",
                table: "UserMatchQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderBoardUsers_LeaderBoards_LeaderBoardId",
                table: "LeaderBoardUsers",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderBoardUsers_LeaderBoards_LeaderBoardId",
                table: "LeaderBoardUsers");

            migrationBuilder.DropTable(
                name: "TeamMatchQuestions");

            migrationBuilder.DropTable(
                name: "UserMatchQuestions");

            migrationBuilder.DropTable(
                name: "TeamMatches");

            migrationBuilder.DropTable(
                name: "UserMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderBoardUsers",
                table: "LeaderBoardUsers");

            migrationBuilder.DropColumn(
                name: "AwardId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestantNumber",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "IsPeriodic",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "MatchFrequency",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "PeriodType",
                table: "Contests");

            migrationBuilder.RenameTable(
                name: "LeaderBoardUsers",
                newName: "LeaderBoardUser");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderBoardUsers_LeaderBoardId",
                table: "LeaderBoardUser",
                newName: "IX_LeaderBoardUser_LeaderBoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaderBoardUser",
                table: "LeaderBoardUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchivedBy = table.Column<int>(type: "int", nullable: false),
                    ArchivedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsLeagueMatch = table.Column<bool>(type: "bit", nullable: false),
                    IsTeamMatch = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team1Id = table.Column<int>(type: "int", nullable: false),
                    Team2Id = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchQuestions_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ContestId",
                table: "Matches",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchQuestions_MatchId",
                table: "MatchQuestions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchQuestions_QuestionId",
                table: "MatchQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderBoardUser_LeaderBoards_LeaderBoardId",
                table: "LeaderBoardUser",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

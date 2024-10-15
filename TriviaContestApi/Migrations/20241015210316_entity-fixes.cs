using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaContestApi.Migrations
{
    /// <inheritdoc />
    public partial class entityfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchQuestions_TeamMatches_MatchId",
                table: "TeamMatchQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMatchQuestions_UserMatches_MatchId",
                table: "UserMatchQuestions");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "UserMatchQuestions",
                newName: "UserMatchId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMatchQuestions_MatchId",
                table: "UserMatchQuestions",
                newName: "IX_UserMatchQuestions_UserMatchId");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "TeamMatchQuestions",
                newName: "TeamMatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMatchQuestions_MatchId",
                table: "TeamMatchQuestions",
                newName: "IX_TeamMatchQuestions_TeamMatchId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "LeaderBoards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "LeaderBoards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ContestUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestUser_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestUser_ContestId",
                table: "ContestUser",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchQuestions_TeamMatches_TeamMatchId",
                table: "TeamMatchQuestions",
                column: "TeamMatchId",
                principalTable: "TeamMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMatchQuestions_UserMatches_UserMatchId",
                table: "UserMatchQuestions",
                column: "UserMatchId",
                principalTable: "UserMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchQuestions_TeamMatches_TeamMatchId",
                table: "TeamMatchQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMatchQuestions_UserMatches_UserMatchId",
                table: "UserMatchQuestions");

            migrationBuilder.DropTable(
                name: "ContestUser");

            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "LeaderBoards");

            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "LeaderBoards");

            migrationBuilder.RenameColumn(
                name: "UserMatchId",
                table: "UserMatchQuestions",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMatchQuestions_UserMatchId",
                table: "UserMatchQuestions",
                newName: "IX_UserMatchQuestions_MatchId");

            migrationBuilder.RenameColumn(
                name: "TeamMatchId",
                table: "TeamMatchQuestions",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMatchQuestions_TeamMatchId",
                table: "TeamMatchQuestions",
                newName: "IX_TeamMatchQuestions_MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchQuestions_TeamMatches_MatchId",
                table: "TeamMatchQuestions",
                column: "MatchId",
                principalTable: "TeamMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMatchQuestions_UserMatches_MatchId",
                table: "UserMatchQuestions",
                column: "MatchId",
                principalTable: "UserMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

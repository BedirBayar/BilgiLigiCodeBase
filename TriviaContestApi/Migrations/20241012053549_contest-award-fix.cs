using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaContestApi.Migrations
{
    /// <inheritdoc />
    public partial class contestawardfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "PrizeRating",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ContestAwards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContestAwards");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "ContestAwards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "ContestAwards");

            migrationBuilder.AddColumn<int>(
                name: "AwardId",
                table: "Contests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrizeRating",
                table: "Contests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ContestAwards",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContestAwards",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}

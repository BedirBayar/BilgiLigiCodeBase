using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgiLigiRatingApi.Migrations
{
    /// <inheritdoc />
    public partial class dbnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insignia",
                table: "Ranks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Insignia",
                table: "Ranks");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgiLigiContributionApi.Migrations
{
    /// <inheritdoc />
    public partial class dbnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArchivedBy",
                table: "QuestionQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedOn",
                table: "QuestionQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "QuestionQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QuestionQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionQuality",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "QuestionQuality",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "QuestionQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "QuestionQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArchivedBy",
                table: "QuestionDraftQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedOn",
                table: "QuestionDraftQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "QuestionDraftQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QuestionDraftQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionDraftQuality",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "QuestionDraftQuality",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "QuestionDraftQuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "QuestionDraftQuality",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArchivedBy",
                table: "QuestionDraftDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedOn",
                table: "QuestionDraftDifficulty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "QuestionDraftDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QuestionDraftDifficulty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionDraftDifficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "QuestionDraftDifficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "QuestionDraftDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "QuestionDraftDifficulty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArchivedBy",
                table: "QuestionDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedOn",
                table: "QuestionDifficulty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "QuestionDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QuestionDifficulty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionDifficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "QuestionDifficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "QuestionDifficulty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "QuestionDifficulty",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "ArchivedOn",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "QuestionQuality");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "ArchivedOn",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "QuestionDraftQuality");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "ArchivedOn",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "QuestionDraftDifficulty");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "ArchivedOn",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuestionDifficulty");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "QuestionDifficulty");
        }
    }
}

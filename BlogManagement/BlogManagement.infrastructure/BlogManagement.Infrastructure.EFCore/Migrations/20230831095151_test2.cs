using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateionDate",
                table: "Articles",
                newName: "ModifyAt");

            migrationBuilder.RenameColumn(
                name: "CreateionDate",
                table: "ArticleCategories",
                newName: "ModifyAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibled",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ArticleCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArticleCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibled",
                table: "ArticleCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsVisibled",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "IsVisibled",
                table: "ArticleCategories");

            migrationBuilder.RenameColumn(
                name: "ModifyAt",
                table: "Articles",
                newName: "CreateionDate");

            migrationBuilder.RenameColumn(
                name: "ModifyAt",
                table: "ArticleCategories",
                newName: "CreateionDate");
        }
    }
}

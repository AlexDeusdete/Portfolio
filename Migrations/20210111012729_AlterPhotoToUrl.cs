using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class AlterPhotoToUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "People",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "People");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "People",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "People",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}

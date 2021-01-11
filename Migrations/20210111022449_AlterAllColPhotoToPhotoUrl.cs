using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class AlterAllColPhotoToPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Portfolio_Projects_Images");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Portfolio_ImagesDB");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Portfolio_Projects_Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Portfolio_ImagesDB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Portfolio_Projects_Images");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Portfolio_ImagesDB");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Portfolio_Projects_Images",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Portfolio_ImagesDB",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

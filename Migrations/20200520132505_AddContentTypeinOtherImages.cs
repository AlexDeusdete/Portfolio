using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class AddContentTypeinOtherImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentTypeImage",
                table: "Portfolio_Projects_Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentTypeImage",
                table: "Portfolio_ImagesDB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentTypeImage",
                table: "Portfolio_Projects_Images");

            migrationBuilder.DropColumn(
                name: "ContentTypeImage",
                table: "Portfolio_ImagesDB");
        }
    }
}

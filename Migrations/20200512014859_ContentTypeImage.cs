using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class ContentTypeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "ContentTypeImage",
                table: "People",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentTypeImage",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "People",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class AddMultToolsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Portfolio_ProjectsDB");

            migrationBuilder.AddColumn<string>(
                name: "InternalTools",
                table: "Portfolio_ProjectsDB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalTools",
                table: "Portfolio_ProjectsDB");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Portfolio_ProjectsDB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

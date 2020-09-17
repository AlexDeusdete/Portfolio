using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class CreateLinkBetUserAndProtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersID",
                table: "Portfolios",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUsersID",
                table: "Portfolios");
        }
    }
}

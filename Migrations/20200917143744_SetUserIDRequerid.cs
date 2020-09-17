using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class SetUserIDRequerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersID",
                table: "Portfolios",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersID",
                table: "Portfolios",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }
    }
}

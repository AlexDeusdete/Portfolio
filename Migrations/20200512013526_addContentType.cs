using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class addContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_People_PersonID",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameIndex(
                name: "IX_Education_PersonID",
                table: "Educations",
                newName: "IX_Educations_PersonID");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "People",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_People_PersonID",
                table: "Educations",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_People_PersonID",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "People");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonID",
                table: "Education",
                newName: "IX_Education_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_People_PersonID",
                table: "Education",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

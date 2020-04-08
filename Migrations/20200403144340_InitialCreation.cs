using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjPortfolio.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    PhotoName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person_SocialMedias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: false),
                    SocialMedia = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    AccessLink = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_SocialMedias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Person_SocialMedias_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateCriation = table.Column<DateTime>(nullable: false),
                    FristColorArgb = table.Column<int>(nullable: false),
                    SecondColorArgb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolios_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio_ImagesDB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    PhotoName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio_ImagesDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolio_ImagesDB_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio_ProjectsDB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    GitHub = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Language = table.Column<int>(nullable: false),
                    DateCriation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio_ProjectsDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolio_ProjectsDB_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio_Projects_Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portfolio_ProjectsID = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    PhotoName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio_Projects_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolio_Projects_Images_Portfolio_ProjectsDB_Portfolio_ProjectsID",
                        column: x => x.Portfolio_ProjectsID,
                        principalTable: "Portfolio_ProjectsDB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_SocialMedias_PersonID",
                table: "Person_SocialMedias",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ImagesDB_PortfolioID",
                table: "Portfolio_ImagesDB",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Projects_Images_Portfolio_ProjectsID",
                table: "Portfolio_Projects_Images",
                column: "Portfolio_ProjectsID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ProjectsDB_PortfolioID",
                table: "Portfolio_ProjectsDB",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_PersonID",
                table: "Portfolios",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person_SocialMedias");

            migrationBuilder.DropTable(
                name: "Portfolio_ImagesDB");

            migrationBuilder.DropTable(
                name: "Portfolio_Projects_Images");

            migrationBuilder.DropTable(
                name: "Portfolio_ProjectsDB");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

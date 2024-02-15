using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalNFE.Register.Companies.Data.Migrations
{
    public partial class InitialRegiterCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(100)", nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    StateRegistration = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    CompanyType = table.Column<int>(type: "integer", nullable: false),
                    CompanyStatus = table.Column<int>(type: "integer", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AffiliateCompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    RootCompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyStatus = table.Column<int>(type: "integer", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Affiliate_Company_RootCompanyId",
                        column: x => x.RootCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    Number = table.Column<string>(type: "varchar(20)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(30)", nullable: false),
                    State = table.Column<string>(type: "varchar(30)", nullable: false),
                    Country = table.Column<string>(type: "varchar(30)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(140)", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affiliate_RootCompanyId",
                table: "Affiliate",
                column: "RootCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyId",
                table: "CompanyAddress",
                column: "CompanyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affiliate");

            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}

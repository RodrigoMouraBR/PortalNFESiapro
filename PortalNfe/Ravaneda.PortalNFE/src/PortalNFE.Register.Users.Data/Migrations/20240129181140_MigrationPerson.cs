using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalNFE.Register.Users.Data.Migrations
{
    public partial class MigrationPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssociatePersonAndCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatePersonAndCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(14)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPerson", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociatePersonAndCompany");

            migrationBuilder.DropTable(
                name: "UserPerson");
        }
    }
}

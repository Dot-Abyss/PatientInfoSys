using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientInfoSys.Persistance.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    fileNo = table.Column<int>(nullable: false),
                    citizenId = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    natinality = table.Column<string>(nullable: true),
                    birthDate = table.Column<DateTime>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    address1 = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    contactPerson = table.Column<string>(nullable: true),
                    contactRelation = table.Column<string>(nullable: true),
                    contactPhone = table.Column<string>(nullable: true),
                    firstVisitDate = table.Column<DateTime>(nullable: false),
                    recordCreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}

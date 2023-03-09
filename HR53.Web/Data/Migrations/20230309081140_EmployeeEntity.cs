using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR53.Web.Data.Migrations
{
    public partial class EmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Companies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

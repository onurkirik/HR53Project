using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR53.Repository.Migrations
{
    public partial class editedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAdvances_Employees_EmployeeId",
                table: "EmployeeAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeExpenditures_Employees_EmployeeId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeExpenditures_EmployeeId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAdvances_EmployeeId",
                table: "EmployeeAdvances");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeAdvances");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployeeExpenditures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployeeAdvances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpenditures_UserId",
                table: "EmployeeExpenditures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdvances_UserId",
                table: "EmployeeAdvances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAdvances_AspNetUsers_UserId",
                table: "EmployeeAdvances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeExpenditures_AspNetUsers_UserId",
                table: "EmployeeExpenditures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAdvances_AspNetUsers_UserId",
                table: "EmployeeAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeExpenditures_AspNetUsers_UserId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeExpenditures_UserId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAdvances_UserId",
                table: "EmployeeAdvances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeExpenditures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeAdvances");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeExpenditures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeAdvances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpenditures_EmployeeId",
                table: "EmployeeExpenditures",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdvances_EmployeeId",
                table: "EmployeeAdvances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAdvances_Employees_EmployeeId",
                table: "EmployeeAdvances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeExpenditures_Employees_EmployeeId",
                table: "EmployeeExpenditures",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

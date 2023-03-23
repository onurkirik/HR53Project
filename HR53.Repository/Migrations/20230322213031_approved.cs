using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR53.Repository.Migrations
{
    public partial class approved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "EmployeeAdvances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "EmployeeAdvances");
        }
    }
}

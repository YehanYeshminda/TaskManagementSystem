using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedUnitDepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_DepartmentId",
                table: "Unit",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Departments_DepartmentId",
                table: "Unit",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Departments_DepartmentId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_DepartmentId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Unit");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class initialCreatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_AppUserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_AppUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_AppUserId",
                table: "Department",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_AppUserId",
                table: "Department",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

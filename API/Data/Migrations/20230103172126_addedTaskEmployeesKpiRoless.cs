using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedTaskEmployeesKpiRoless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetRoles_AppRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeKpis_AppRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropColumn(
                name: "UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.RenameColumn(
                name: "UserRolesUserId",
                table: "EmployeeKpis",
                newName: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpis_AppUserId",
                table: "EmployeeKpis",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpis_AspNetUsers_AppUserId",
                table: "EmployeeKpis",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetUsers_AppUserId",
                table: "EmployeeKpis");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeKpis_AppUserId",
                table: "EmployeeKpis");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "EmployeeKpis",
                newName: "UserRolesUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "EmployeeKpis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRolesRoleId",
                table: "EmployeeKpis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpis_AppRoleId",
                table: "EmployeeKpis",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpis_AspNetRoles_AppRoleId",
                table: "EmployeeKpis",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpis_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" });
        }
    }
}

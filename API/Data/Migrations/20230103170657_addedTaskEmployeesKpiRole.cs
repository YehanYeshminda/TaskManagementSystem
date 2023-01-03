using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedTaskEmployeesKpiRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropColumn(
                name: "UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropColumn(
                name: "UserRolesUserId",
                table: "EmployeeKpis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRolesRoleId",
                table: "EmployeeKpis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRolesUserId",
                table: "EmployeeKpis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpis_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" });
        }
    }
}

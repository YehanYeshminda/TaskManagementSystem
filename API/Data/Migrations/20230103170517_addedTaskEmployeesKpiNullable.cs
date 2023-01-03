using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedTaskEmployeesKpiNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpi_AspNetRoles_AppRoleId",
                table: "EmployeeKpi");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpi_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpi");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpi_Product_ProductId",
                table: "EmployeeKpi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeKpi",
                table: "EmployeeKpi");

            migrationBuilder.RenameTable(
                name: "EmployeeKpi",
                newName: "EmployeeKpis");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpi_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis",
                newName: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpi_ProductId",
                table: "EmployeeKpis",
                newName: "IX_EmployeeKpis_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpi_AppRoleId",
                table: "EmployeeKpis",
                newName: "IX_EmployeeKpis_AppRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeKpis",
                table: "EmployeeKpis",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpis_Product_ProductId",
                table: "EmployeeKpis",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetRoles_AppRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpis");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeKpis_Product_ProductId",
                table: "EmployeeKpis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeKpis",
                table: "EmployeeKpis");

            migrationBuilder.RenameTable(
                name: "EmployeeKpis",
                newName: "EmployeeKpi");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpis_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpi",
                newName: "IX_EmployeeKpi_UserRolesUserId_UserRolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpis_ProductId",
                table: "EmployeeKpi",
                newName: "IX_EmployeeKpi_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeKpis_AppRoleId",
                table: "EmployeeKpi",
                newName: "IX_EmployeeKpi_AppRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeKpi",
                table: "EmployeeKpi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpi_AspNetRoles_AppRoleId",
                table: "EmployeeKpi",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpi_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpi",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeKpi_Product_ProductId",
                table: "EmployeeKpi",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}

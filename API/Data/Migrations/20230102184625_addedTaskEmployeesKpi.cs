using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedTaskEmployeesKpi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeKpi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyTarget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeeklyTarget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyTarget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserRolesUserId = table.Column<int>(type: "int", nullable: true),
                    UserRolesRoleId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    AppRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeKpi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeKpi_AspNetRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeKpi_AspNetUserRoles_UserRolesUserId_UserRolesRoleId",
                        columns: x => new { x.UserRolesUserId, x.UserRolesRoleId },
                        principalTable: "AspNetUserRoles",
                        principalColumns: new[] { "UserId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_EmployeeKpi_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpi_AppRoleId",
                table: "EmployeeKpi",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpi_ProductId",
                table: "EmployeeKpi",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKpi_UserRolesUserId_UserRolesRoleId",
                table: "EmployeeKpi",
                columns: new[] { "UserRolesUserId", "UserRolesRoleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeKpi");
        }
    }
}

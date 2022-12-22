using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedDepartmentTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShop_Departments_DepartmentId",
                table: "WorkShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShop",
                table: "WorkShop");

            migrationBuilder.RenameTable(
                name: "WorkShop",
                newName: "WorkShops");

            migrationBuilder.RenameIndex(
                name: "IX_WorkShop_DepartmentId",
                table: "WorkShops",
                newName: "IX_WorkShops_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShops",
                table: "WorkShops",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_DepartmentId",
                table: "UserTasks",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShops_Departments_DepartmentId",
                table: "WorkShops",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShops_Departments_DepartmentId",
                table: "WorkShops");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShops",
                table: "WorkShops");

            migrationBuilder.RenameTable(
                name: "WorkShops",
                newName: "WorkShop");

            migrationBuilder.RenameIndex(
                name: "IX_WorkShops_DepartmentId",
                table: "WorkShop",
                newName: "IX_WorkShop_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShop",
                table: "WorkShop",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShop_Departments_DepartmentId",
                table: "WorkShop",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}

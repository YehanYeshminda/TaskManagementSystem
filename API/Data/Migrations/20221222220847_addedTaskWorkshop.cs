using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedTaskWorkshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkShopId",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_WorkShopId",
                table: "UserTasks",
                column: "WorkShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_WorkShops_WorkShopId",
                table: "UserTasks",
                column: "WorkShopId",
                principalTable: "WorkShops",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_WorkShops_WorkShopId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_WorkShopId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "WorkShopId",
                table: "UserTasks");
        }
    }
}

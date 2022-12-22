using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addeCompanyPlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Plant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plant_CompanyId",
                table: "Plant",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Company_CompanyId",
                table: "Plant",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Company_CompanyId",
                table: "Plant");

            migrationBuilder.DropIndex(
                name: "IX_Plant_CompanyId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Plant");
        }
    }
}

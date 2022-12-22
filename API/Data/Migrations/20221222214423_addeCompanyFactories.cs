using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addeCompanyFactories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Factory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factory_CompanyId",
                table: "Factory",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_Company_CompanyId",
                table: "Factory",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_Company_CompanyId",
                table: "Factory");

            migrationBuilder.DropIndex(
                name: "IX_Factory_CompanyId",
                table: "Factory");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Factory");
        }
    }
}

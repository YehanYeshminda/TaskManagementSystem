using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addedMaterialDataTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decimal",
                table: "Materials");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Materials",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "Decimal",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

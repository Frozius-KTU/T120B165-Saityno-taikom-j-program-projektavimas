using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPartsShop.Infrastructure.Migrations
{
    public partial class local2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "CarParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "CarParts");
        }
    }
}

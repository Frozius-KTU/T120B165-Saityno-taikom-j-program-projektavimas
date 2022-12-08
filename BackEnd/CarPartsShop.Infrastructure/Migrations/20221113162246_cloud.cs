using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPartsShop.Infrastructure.Migrations
{
    public partial class cloud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarBrands",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_UserId",
                table: "CarBrands",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBrands_AspNetUsers_UserId",
                table: "CarBrands",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBrands_AspNetUsers_UserId",
                table: "CarBrands");

            migrationBuilder.DropIndex(
                name: "IX_CarBrands_UserId",
                table: "CarBrands");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarBrands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPartsShop.Infrastructure.Migrations
{
    public partial class cloud1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CarParts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CarParts_UserId",
                table: "CarParts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_UserId",
                table: "CarModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_AspNetUsers_UserId",
                table: "CarModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarParts_AspNetUsers_UserId",
                table: "CarParts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_AspNetUsers_UserId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarParts_AspNetUsers_UserId",
                table: "CarParts");

            migrationBuilder.DropIndex(
                name: "IX_CarParts_UserId",
                table: "CarParts");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_UserId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarModels");
        }
    }
}

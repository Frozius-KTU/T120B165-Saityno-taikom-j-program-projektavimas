using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPartsShop.Infrastructure.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CarBrands");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CarBrands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CarParts",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "CarParts",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CarModels",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "CarModels",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CarBrands",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "CarBrands",
                type: "datetimeoffset",
                nullable: true);
        }
    }
}

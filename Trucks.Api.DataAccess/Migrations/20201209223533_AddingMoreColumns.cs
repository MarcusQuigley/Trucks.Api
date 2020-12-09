using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class AddingMoreColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Damaged",
                table: "Trucks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DefaultPhotoPath",
                table: "Trucks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Trucks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Trucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TruckInventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damaged",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "DefaultPhotoPath",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TruckInventories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class AddingLinkTrucktoTruckInventory5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Trucks");

            migrationBuilder.AlterColumn<int>(
                name: "TruckInventoryId",
                table: "Trucks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks",
                column: "TruckInventoryId",
                principalTable: "TruckInventories",
                principalColumn: "TruckInventoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks");

            migrationBuilder.AlterColumn<int>(
                name: "TruckInventoryId",
                table: "Trucks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Trucks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks",
                column: "TruckInventoryId",
                principalTable: "TruckInventories",
                principalColumn: "TruckInventoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class AddingLinkTrucktoTruckInventory4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Trucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TruckInventoryId",
                table: "Trucks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TruckInventoryId",
                table: "Trucks",
                column: "TruckInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks",
                column: "TruckInventoryId",
                principalTable: "TruckInventories",
                principalColumn: "TruckInventoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_TruckInventories_TruckInventoryId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_TruckInventoryId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "TruckInventoryId",
                table: "Trucks");
        }
    }
}

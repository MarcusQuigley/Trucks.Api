using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class Addingphototable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Trucks_TruckId",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "TruckPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_TruckId",
                table: "TruckPhotos",
                newName: "IX_TruckPhotos_TruckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TruckPhotos",
                table: "TruckPhotos",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPhotos_Trucks_TruckId",
                table: "TruckPhotos",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "TruckId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckPhotos_Trucks_TruckId",
                table: "TruckPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TruckPhotos",
                table: "TruckPhotos");

            migrationBuilder.RenameTable(
                name: "TruckPhotos",
                newName: "Photo");

            migrationBuilder.RenameIndex(
                name: "IX_TruckPhotos_TruckId",
                table: "Photo",
                newName: "IX_Photo_TruckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Trucks_TruckId",
                table: "Photo",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "TruckId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

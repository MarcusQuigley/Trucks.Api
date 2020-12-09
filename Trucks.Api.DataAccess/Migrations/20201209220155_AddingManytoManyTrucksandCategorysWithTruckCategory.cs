using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class AddingManytoManyTrucksandCategorysWithTruckCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckCategories",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCategories", x => new { x.CategoryId, x.TruckId });
                    table.ForeignKey(
                        name: "FK_TruckCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCategories_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategories_TruckId",
                table: "TruckCategories",
                column: "TruckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckCategories");
        }
    }
}

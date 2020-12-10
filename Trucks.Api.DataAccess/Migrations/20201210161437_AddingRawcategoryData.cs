using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Api.DataAccess.Migrations
{
    public partial class AddingRawcategoryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO trucks.categories (name) VALUES('1980 Mini Trucks')");
            // migrationBuilder.Sql("INSERT INTO trucks.categories (name) VALUES('1990 Mini Trucks')");
            //  migrationBuilder.Sql("INSERT INTO trucks.categories (name) VALUES('2000 Mini Trucks')");
            //migrationBuilder.Sql("INSERT INTO Category VALUES('1980's Trucks')");
            //migrationBuilder.Sql("INSERT INTO Category VALUES('1990's Trucks')");
            //migrationBuilder.Sql("INSERT INTO Category VALUES('2000's Trucks')");
            //migrationBuilder.Sql("INSERT INTO Category VALUES('2010's Trucks')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

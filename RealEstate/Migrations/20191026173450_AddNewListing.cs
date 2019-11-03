using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class AddNewListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "Address", "Company", "Image", "Price" },
                values: new object[] { 2, "10 4TH St, San Francisco", "Golden RealEstate", "thumb-005", 599000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2);
        }
    }
}

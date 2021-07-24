using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationApi.Migrations
{
    public partial class LocationApiModelsLocationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FleetID = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationID", "FleetID", "Latitude", "Longitude" },
                values: new object[] { 1, 1, 23.235323000000001, 90.392723000000004 });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationID", "FleetID", "Latitude", "Longitude" },
                values: new object[] { 2, 2, 53.235323000000001, 73.472921999999997 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}

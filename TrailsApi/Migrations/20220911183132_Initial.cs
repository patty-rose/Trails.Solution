using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrailMarkers",
                columns: table => new
                {
                    TrailMarkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Longitude = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    isTrailhead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isLandmark = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailMarkers", x => x.TrailMarkerId);
                });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "isLandmark", "isTrailhead" },
                values: new object[] { 1, "dirt trail off of Springwater", 2, 1, "Powell Butte Trailhead", false, true });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "isLandmark", "isTrailhead" },
                values: new object[] { 2, "pond that seasonally has many frogs and frogs sounds", 4, 3, "Oaks Bottom Frog Pond", true, false });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "isLandmark", "isTrailhead" },
                values: new object[] { 3, "when you arrive to the lighthouse you have reached end of the trail! Enjoy!", 6, 5, "Sauvies Island Lighthouse", true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailMarkers");
        }
    }
}

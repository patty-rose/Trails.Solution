using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trails.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Difficulty = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });

            migrationBuilder.CreateTable(
                name: "TrailMarkers",
                columns: table => new
                {
                    TrailMarkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrailId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    isTrailhead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isLandmark = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailMarkers", x => x.TrailMarkerId);
                    table.ForeignKey(
                        name: "FK_TrailMarkers_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Description", "Difficulty", "Name" },
                values: new object[] { 1, "practice trail", "medium", "Seed Trail" });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "TrailId", "isLandmark", "isTrailhead" },
                values: new object[] { 1, "dirt trail off of Springwater", 45.490696, -122.49699200000001, "Powell Butte Trailhead", 1, false, true });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "TrailId", "isLandmark", "isTrailhead" },
                values: new object[] { 2, "pond that seasonally has many frogs and frogs sounds", 45.485812000000003, -122.649976, "Oaks Bottom Frog Pond", 1, true, false });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "TrailId", "isLandmark", "isTrailhead" },
                values: new object[] { 3, "when you arrive to the lighthouse you have reached end of the trail! Enjoy!", 45.848579999999998, -122.78834999999999, "Sauvies Island Lighthouse", 1, true, false });

            migrationBuilder.CreateIndex(
                name: "IX_TrailMarkers_TrailId",
                table: "TrailMarkers",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailMarkers");

            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}

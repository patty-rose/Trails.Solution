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
                values: new object[] { 1, "stroll through Laurelhurst Park", "easy", "Laurelhurst Stroll" });

            migrationBuilder.InsertData(
                table: "TrailMarkers",
                columns: new[] { "TrailMarkerId", "Description", "Latitude", "Longitude", "Name", "TrailId", "isLandmark", "isTrailhead" },
                values: new object[,]
                {
                    { 1, null, 45.522210000000001, -122.62578000000001, null, 1, false, false },
                    { 2, null, 45.522060000000003, -122.62634, null, 1, false, false },
                    { 3, null, 45.521389999999997, -122.62942, null, 1, false, false },
                    { 4, null, 45.521099999999997, -122.63052, null, 1, false, false },
                    { 5, null, 45.520679999999999, -122.63084000000001, null, 1, false, false },
                    { 6, null, 45.521450000000002, -122.62761, null, 1, false, false },
                    { 7, null, 45.52055, -122.6259, null, 1, false, false },
                    { 8, null, 45.520380000000003, -122.62324, null, 1, false, false }
                });

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

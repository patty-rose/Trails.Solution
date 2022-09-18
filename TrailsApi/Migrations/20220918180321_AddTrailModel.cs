using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class AddTrailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrailId",
                table: "TrailMarkers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Difficulty = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Miles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrailMarkers_TrailId",
                table: "TrailMarkers",
                column: "TrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrailMarkers_Trails_TrailId",
                table: "TrailMarkers",
                column: "TrailId",
                principalTable: "Trails",
                principalColumn: "TrailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrailMarkers_Trails_TrailId",
                table: "TrailMarkers");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_TrailMarkers_TrailId",
                table: "TrailMarkers");

            migrationBuilder.DropColumn(
                name: "TrailId",
                table: "TrailMarkers");
        }
    }
}

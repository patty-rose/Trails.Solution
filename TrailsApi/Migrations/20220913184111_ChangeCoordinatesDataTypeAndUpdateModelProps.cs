using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class ChangeCoordinatesDataTypeAndUpdateModelProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "TrailMarkers",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "TrailMarkers",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 45.490696, -122.49699200000001 });

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 45.485812000000003, -122.649976 });

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 45.848579999999998, -122.78834999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "TrailMarkers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "TrailMarkers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "TrailMarkers",
                keyColumn: "TrailMarkerId",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 6, 5 });
        }
    }
}

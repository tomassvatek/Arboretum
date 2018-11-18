using Microsoft.EntityFrameworkCore.Migrations;

namespace Arboretum.Persistence.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dendrologies",
                columns: new[] { "Id", "About", "CommonName", "ScientificName" },
                values: new object[] { 1, null, "Bříza", "bříza latinsky" });

            migrationBuilder.InsertData(
                table: "Dendrologies",
                columns: new[] { "Id", "About", "CommonName", "ScientificName" },
                values: new object[] { 2, null, "Buk", "buk latinsky" });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "Age", "CrownSize", "DendrologyId", "Height", "Latitude", "Longitude", "Note", "TrunkSize" },
                values: new object[] { 1, 50, 20.0, 1, null, 49.53313, 14.80902, null, null });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "Age", "CrownSize", "DendrologyId", "Height", "Latitude", "Longitude", "Note", "TrunkSize" },
                values: new object[] { 2, 80, 20.0, 2, null, 49.53314, 14.80903, null, null });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "Age", "CrownSize", "DendrologyId", "Height", "Latitude", "Longitude", "Note", "TrunkSize" },
                values: new object[] { 3, 90, 208.0, 2, null, 49.53304, 14.809039, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dendrologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dendrologies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

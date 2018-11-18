using Microsoft.EntityFrameworkCore.Migrations;

namespace Arboretum.Persistence.Migrations
{
    public partial class SeedTreeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "Age", "CrownSize", "DendrologyId", "Height", "Latitude", "Longitude", "Note", "TrunkSize" },
                values: new object[] { 4, 90, 208.0, 1, null, 49.53304, 14.809039, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FindArt.DataAccess.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2886e9e4-359f-49b2-a89e-b0e493b9d795", "569f4123-cbfc-4dda-8684-d5e210d526cd", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2886e9e4-359f-49b2-a89e-b0e493b9d795");
        }
    }
}

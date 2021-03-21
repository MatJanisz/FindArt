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
                values: new object[] { "5a069a60-d931-4ad5-a068-0062d5ea99c6", "bb4c30dc-d528-48c6-b208-b56d6428d19c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a069a60-d931-4ad5-a068-0062d5ea99c6");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FindArt.DataAccess.Migrations
{
    public partial class AddTrueAsDefaultValueToActiveColumnInAuctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cec124bd-cc75-4a87-ac75-938dec23139d");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef4a7b7c-24d3-4655-b503-9e5711ce2b0e", "02aeebef-9ceb-4f92-bc16-e5513046852b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4a7b7c-24d3-4655-b503-9e5711ce2b0e");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Auctions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cec124bd-cc75-4a87-ac75-938dec23139d", "2b993858-2063-4064-afe8-295b9e4e457d", "Administrator", "ADMINISTRATOR" });
        }
    }
}

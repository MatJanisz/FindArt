using Microsoft.EntityFrameworkCore.Migrations;

namespace FindArt.DataAccess.Migrations
{
    public partial class AddProductTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTypeID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeID);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeID", "Name" },
                values: new object[,]
                {
                    { 0, "Painting" },
                    { 1, "Drawing" },
                    { 2, "Graphics" },
                    { 3, "Calligraphy" },
                    { 4, "Fotography" },
                    { 5, "Architecture" },
                    { 6, "Sculpture" },
                    { 7, "Ceramics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products",
                column: "ProductTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products",
                column: "ProductTypeID",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeID",
                table: "Products");
        }
    }
}

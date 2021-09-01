using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _4444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteLists_FavoriteToProducts_FavoriteToProductProductId_FavoriteToProductFavoriteListId",
                table: "FavoriteLists");

            migrationBuilder.DropTable(
                name: "FavoriteToProductProduct");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteLists_FavoriteToProductProductId_FavoriteToProductFavoriteListId",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "RatingDetail",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "FavoriteToProductFavoriteListId",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "FavoriteToProductProductId",
                table: "FavoriteLists");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteToProducts_FavoriteListId",
                table: "FavoriteToProducts",
                column: "FavoriteListId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteToProducts_FavoriteLists_FavoriteListId",
                table: "FavoriteToProducts",
                column: "FavoriteListId",
                principalTable: "FavoriteLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteToProducts_Products_ProductId",
                table: "FavoriteToProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteToProducts_FavoriteLists_FavoriteListId",
                table: "FavoriteToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteToProducts_Products_ProductId",
                table: "FavoriteToProducts");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteToProducts_FavoriteListId",
                table: "FavoriteToProducts");

            migrationBuilder.AddColumn<int>(
                name: "RatingDetail",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteToProductFavoriteListId",
                table: "FavoriteLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteToProductProductId",
                table: "FavoriteLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteToProductProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    FavoriteToProductsProductId = table.Column<int>(type: "int", nullable: false),
                    FavoriteToProductsFavoriteListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteToProductProduct", x => new { x.ProductsId, x.FavoriteToProductsProductId, x.FavoriteToProductsFavoriteListId });
                    table.ForeignKey(
                        name: "FK_FavoriteToProductProduct_FavoriteToProducts_FavoriteToProductsProductId_FavoriteToProductsFavoriteListId",
                        columns: x => new { x.FavoriteToProductsProductId, x.FavoriteToProductsFavoriteListId },
                        principalTable: "FavoriteToProducts",
                        principalColumns: new[] { "ProductId", "FavoriteListId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteToProductProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteLists_FavoriteToProductProductId_FavoriteToProductFavoriteListId",
                table: "FavoriteLists",
                columns: new[] { "FavoriteToProductProductId", "FavoriteToProductFavoriteListId" });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteToProductProduct_FavoriteToProductsProductId_FavoriteToProductsFavoriteListId",
                table: "FavoriteToProductProduct",
                columns: new[] { "FavoriteToProductsProductId", "FavoriteToProductsFavoriteListId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteLists_FavoriteToProducts_FavoriteToProductProductId_FavoriteToProductFavoriteListId",
                table: "FavoriteLists",
                columns: new[] { "FavoriteToProductProductId", "FavoriteToProductFavoriteListId" },
                principalTable: "FavoriteToProducts",
                principalColumns: new[] { "ProductId", "FavoriteListId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

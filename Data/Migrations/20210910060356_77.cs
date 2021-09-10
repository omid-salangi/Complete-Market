using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _77 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FavoriteLists_FavoriteListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ratings_RatingId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RatingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserChangeId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserChangeId",
                table: "FavoriteLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IdentityUserChangeId",
                table: "Ratings",
                column: "IdentityUserChangeId",
                unique: true,
                filter: "[IdentityUserChangeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteLists_IdentityUserChangeId",
                table: "FavoriteLists",
                column: "IdentityUserChangeId",
                unique: true,
                filter: "[IdentityUserChangeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteLists_AspNetUsers_IdentityUserChangeId",
                table: "FavoriteLists",
                column: "IdentityUserChangeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_IdentityUserChangeId",
                table: "Ratings",
                column: "IdentityUserChangeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteLists_AspNetUsers_IdentityUserChangeId",
                table: "FavoriteLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_IdentityUserChangeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_IdentityUserChangeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteLists_IdentityUserChangeId",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "IdentityUserChangeId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdentityUserChangeId",
                table: "FavoriteLists");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteListId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteListId",
                table: "AspNetUsers",
                column: "FavoriteListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RatingId",
                table: "AspNetUsers",
                column: "RatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FavoriteLists_FavoriteListId",
                table: "AspNetUsers",
                column: "FavoriteListId",
                principalTable: "FavoriteLists",
                principalColumn: "FavoriteListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ratings_RatingId",
                table: "AspNetUsers",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

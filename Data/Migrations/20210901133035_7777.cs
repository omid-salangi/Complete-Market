using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _7777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FavoriteLists",
                newName: "FavoriteListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteListId",
                table: "FavoriteLists",
                newName: "Id");
        }
    }
}

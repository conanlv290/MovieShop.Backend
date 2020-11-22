using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class UserColNameUpdateTF_LLD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TowFactorEnabled",
                table: "User",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "LoastLoginDateTime",
                table: "User",
                newName: "LastLoginDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "User",
                newName: "TowFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "LastLoginDateTime",
                table: "User",
                newName: "LoastLoginDateTime");
        }
    }
}

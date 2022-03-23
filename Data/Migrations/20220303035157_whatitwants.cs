using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class whatitwants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Twit_Users_UserId",
                table: "Twit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Twit",
                table: "Twit");

            migrationBuilder.RenameTable(
                name: "Twit",
                newName: "Twits");

            migrationBuilder.RenameIndex(
                name: "IX_Twit_UserId",
                table: "Twits",
                newName: "IX_Twits_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Twits",
                table: "Twits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Twits_Users_UserId",
                table: "Twits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Twits_Users_UserId",
                table: "Twits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Twits",
                table: "Twits");

            migrationBuilder.RenameTable(
                name: "Twits",
                newName: "Twit");

            migrationBuilder.RenameIndex(
                name: "IX_Twits_UserId",
                table: "Twit",
                newName: "IX_Twit_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Twit",
                table: "Twit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Twit_Users_UserId",
                table: "Twit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

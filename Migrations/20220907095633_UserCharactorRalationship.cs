using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UserCharactorRalationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Charactors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charactors_UserId",
                table: "Charactors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charactors_Users_UserId",
                table: "Charactors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charactors_Users_UserId",
                table: "Charactors");

            migrationBuilder.DropIndex(
                name: "IX_Charactors_UserId",
                table: "Charactors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Charactors");
        }
    }
}

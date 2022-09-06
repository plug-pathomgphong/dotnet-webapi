using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Charactor",
                table: "Charactor");

            migrationBuilder.RenameTable(
                name: "Charactor",
                newName: "Charactors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charactors",
                table: "Charactors",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Charactors",
                table: "Charactors");

            migrationBuilder.RenameTable(
                name: "Charactors",
                newName: "Charactor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charactor",
                table: "Charactor",
                column: "Id");
        }
    }
}

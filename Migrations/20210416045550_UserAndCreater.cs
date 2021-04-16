using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class UserAndCreater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreaterId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CreaterId",
                table: "Sections",
                column: "CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_CreaterId",
                table: "Sections",
                column: "CreaterId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_CreaterId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CreaterId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "Sections");
        }
    }
}

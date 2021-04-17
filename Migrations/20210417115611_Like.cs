using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class Like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikesId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LikeId",
                table: "Users",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LikesId",
                table: "Messages",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Like_LikesId",
                table: "Messages",
                column: "LikesId",
                principalTable: "Like",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Like_LikeId",
                table: "Users",
                column: "LikeId",
                principalTable: "Like",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Like_LikesId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Like_LikeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Users_LikeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Messages_LikesId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

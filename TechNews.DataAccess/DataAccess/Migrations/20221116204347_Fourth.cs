using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechNews.DataAccess.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Admins_CreatorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CreatorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Admins_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Admins_AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Admins_CreatorId",
                table: "Posts",
                column: "CreatorId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}

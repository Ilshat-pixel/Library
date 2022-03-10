using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Persistence.Migrations
{
    public partial class NewConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "LibraryCards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_BookId",
                table: "LibraryCards",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCards_Books_BookId",
                table: "LibraryCards",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCards_Books_BookId",
                table: "LibraryCards");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_BookId",
                table: "LibraryCards");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "LibraryCards");
        }
    }
}

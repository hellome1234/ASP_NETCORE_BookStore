using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE_BookStore.Migrations
{
    public partial class BookCoverPhoto_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCoverPhoto",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCoverPhoto",
                table: "Books");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE_BookStore.Migrations
{
    public partial class BookPDFColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookURL",
                table: "Books");
        }
    }
}

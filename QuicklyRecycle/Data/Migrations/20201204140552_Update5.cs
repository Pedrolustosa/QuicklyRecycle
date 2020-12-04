using Microsoft.EntityFrameworkCore.Migrations;

namespace QuicklyRecycle.Data.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeRecycling",
                table: "Company",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRecycling",
                table: "Company");
        }
    }
}

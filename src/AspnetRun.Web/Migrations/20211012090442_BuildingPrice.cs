using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetRun.Web.Migrations
{
    public partial class BuildingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingPrice",
                table: "Building",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingPrice",
                table: "Building");
        }
    }
}

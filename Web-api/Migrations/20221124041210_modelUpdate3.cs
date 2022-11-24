using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_mrmythical.Migrations
{
    public partial class modelUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameClassRole",
                table: "GameClasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameClassRole",
                table: "GameClasses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_mrmythical.Migrations
{
    public partial class modelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WowheadId",
                table: "Spells",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WowheadId",
                table: "Spells");
        }
    }
}

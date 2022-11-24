using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_mrmythical.Migrations
{
    public partial class modelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WowheadId",
                table: "Spells",
                newName: "Wowhead");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wowhead",
                table: "Spells",
                newName: "WowheadId");
        }
    }
}

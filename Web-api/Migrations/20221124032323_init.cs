using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_mrmythical.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameClasses",
                columns: table => new
                {
                    GameClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameClassName = table.Column<string>(type: "TEXT", nullable: false),
                    GameClassRole = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClasses", x => x.GameClassId);
                });

            migrationBuilder.CreateTable(
                name: "Raids",
                columns: table => new
                {
                    RaidId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaidName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raids", x => x.RaidId);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpellName = table.Column<string>(type: "TEXT", nullable: false),
                    GameClassId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellId);
                    table.ForeignKey(
                        name: "FK_Spells_GameClasses_GameClassId",
                        column: x => x.GameClassId,
                        principalTable: "GameClasses",
                        principalColumn: "GameClassId");
                });

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    BossId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BossName = table.Column<string>(type: "TEXT", nullable: false),
                    RaidId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.BossId);
                    table.ForeignKey(
                        name: "FK_Bosses_Raids_RaidId",
                        column: x => x.RaidId,
                        principalTable: "Raids",
                        principalColumn: "RaidId");
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbiltyName = table.Column<string>(type: "TEXT", nullable: false),
                    BossId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityId);
                    table.ForeignKey(
                        name: "FK_Abilities_Bosses_BossId",
                        column: x => x.BossId,
                        principalTable: "Bosses",
                        principalColumn: "BossId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_BossId",
                table: "Abilities",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_RaidId",
                table: "Bosses",
                column: "RaidId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_GameClassId",
                table: "Spells",
                column: "GameClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropTable(
                name: "GameClasses");

            migrationBuilder.DropTable(
                name: "Raids");
        }
    }
}

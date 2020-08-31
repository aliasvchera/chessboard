using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Civilization = table.Column<string>(nullable: false),
                    Money = table.Column<float>(nullable: false),
                    Reputation = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    SoldierCost = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    SoldierNumber = table.Column<int>(nullable: false),
                    Experience = table.Column<float>(nullable: false),
                    FieldEffectiveness = table.Column<float>(nullable: false),
                    FortressEffectiveness = table.Column<float>(nullable: false),
                    SiegeEffectiveness = table.Column<float>(nullable: false),
                    FactionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Units_Factions_FactionName",
                        column: x => x.FactionName,
                        principalTable: "Factions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionName",
                table: "Units",
                column: "FactionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}

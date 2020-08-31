using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class Regions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    NormalWealth = table.Column<float>(nullable: false),
                    Wealth = table.Column<float>(nullable: false),
                    Faction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class Transitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Civilization",
                table: "Factions",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    TransitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factions = table.Column<string>(nullable: true),
                    Penalty = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.TransitionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.AlterColumn<string>(
                name: "Civilization",
                table: "Factions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }
    }
}

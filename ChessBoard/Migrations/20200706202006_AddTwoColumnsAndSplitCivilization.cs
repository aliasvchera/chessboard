using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class AddTwoColumnsAndSplitCivilization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Factions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pax",
                table: "Factions",
                nullable: true);

            migrationBuilder.Sql(
                @"
                    UPDATE Factions
                    SET Culture = RIGHT(Civilization, LEN(Civilization) - 3)
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "Pax",
                table: "Factions");
        }
    }
}

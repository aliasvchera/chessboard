using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class FactionForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_FactionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Units");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FactionId",
                table: "Units",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class FactionKey3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions1",
                table: "Factions",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Military_FactionId",
                table: "Military",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Factions_FactionId",
                table: "Military",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

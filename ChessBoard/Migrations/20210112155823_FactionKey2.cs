using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class FactionKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionId1",
                table: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionId1",
                table: "Military");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class SplitMilitaryInRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Military_RegionId1",
                table: "Military",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Regions_RegionId1",
                table: "Military",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionId1",
                table: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionId1",
                table: "Military");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class RecreateJoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transitions_RegionId2",
                table: "Transitions",
                column: "RegionId2");

            migrationBuilder.CreateIndex(
                name: "IX_Military_RegionId",
                table: "Military",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Military_RegionId1",
                table: "Military",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Military_FactionId",
                table: "Military",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Regions_RegionId",
                table: "Military",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Regions_RegionId1",
                table: "Military",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Factions_FactionId",
                table: "Military",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Regions_RegionId1",
                table: "Transitions",
                column: "RegionId1",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Regions_RegionId2",
                table: "Transitions",
                column: "RegionId2",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionId",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionId1",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Military_Factions_FactionId",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionId1",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionId2",
                table: "Transitions");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_RegionId2",
                table: "Transitions");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionId",
                table: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionId1",
                table: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Military_FactionId",
                table: "Military");
        }
    }
}

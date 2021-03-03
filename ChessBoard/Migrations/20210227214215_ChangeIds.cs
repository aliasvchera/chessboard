using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class ChangeIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RegionId2",
                table: "Transitions",
                type: "nvarchar(31)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId1",
                table: "Transitions",
                type: "nvarchar(31)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId",
                table: "Regions",
                type: "nvarchar(31)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId",
                table: "Military",
                type: "nvarchar(31)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FactionId",
                table: "Military",
                type: "nvarchar(41)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FactionId",
                table: "Factions",
                type: "nvarchar(41)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MilitaryId",
                table: "Units",
                column: "MilitaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Military_MilitaryId",
                table: "Units",
                column: "MilitaryId",
                principalTable: "Military",
                principalColumn: "MilitaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Military_MilitaryId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MilitaryId",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId2",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId1",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId",
                table: "Regions",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionId",
                table: "Military",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FactionId",
                table: "Military",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(41)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FactionId",
                table: "Factions",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(41)");

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
    }
}

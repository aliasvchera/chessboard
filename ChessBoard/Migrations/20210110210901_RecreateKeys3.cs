using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class RecreateKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MilitaryName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Military");

            migrationBuilder.RenameColumn(
                name: "RegionName2",
                table: "Transitions",
                newName: "RegionId2");

            migrationBuilder.RenameColumn(
                name: "RegionName1",
                table: "Transitions",
                newName: "RegionId1");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_RegionName2",
                table: "Transitions",
                newName: "IX_Transitions_RegionId2");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regions",
                newName: "RegionId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Military",
                newName: "MilitaryId");

            migrationBuilder.AddColumn<string>(
                name: "UnitId",
                table: "Units",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MilitaryId",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionId",
                table: "Military",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MilitaryId",
                table: "Units",
                column: "MilitaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Military_RegionId",
                table: "Military",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Regions_RegionId",
                table: "Military",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
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

        }
    }
}

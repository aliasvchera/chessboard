using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class ReworkingKeyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionName",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionName1",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionName2",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Military_MilitaryName",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MilitaryName",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionName",
                table: "Military");
            /*
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
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionId",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionId1",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionId2",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Military_MilitaryId",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MilitaryId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionId",
                table: "Military");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MilitaryId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Military");

            migrationBuilder.RenameColumn(
                name: "RegionId2",
                table: "Transitions",
                newName: "RegionName2");

            migrationBuilder.RenameColumn(
                name: "RegionId1",
                table: "Transitions",
                newName: "RegionName1");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_RegionId2",
                table: "Transitions",
                newName: "IX_Transitions_RegionName2");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Regions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MilitaryId",
                table: "Military",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MilitaryName",
                table: "Units",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Military",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MilitaryName",
                table: "Units",
                column: "MilitaryName");

            migrationBuilder.CreateIndex(
                name: "IX_Military_RegionName",
                table: "Military",
                column: "RegionName");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Regions_RegionName",
                table: "Military",
                column: "RegionName",
                principalTable: "Regions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Regions_RegionName1",
                table: "Transitions",
                column: "RegionName1",
                principalTable: "Regions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Regions_RegionName2",
                table: "Transitions",
                column: "RegionName2",
                principalTable: "Regions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Military_MilitaryName",
                table: "Units",
                column: "MilitaryName",
                principalTable: "Military",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class RegionsTransactions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionA",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "RegionB",
                table: "Transitions");

            migrationBuilder.AddColumn<string>(
                name: "RegionName1",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegionName2",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions",
                columns: new[] { "RegionName1", "RegionName2" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_RegionName2",
                table: "Transitions",
                column: "RegionName2");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionName1",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionName2",
                table: "Transitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_RegionName2",
                table: "Transitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "RegionName1",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "RegionName2",
                table: "Transitions");

            migrationBuilder.AddColumn<string>(
                name: "RegionA",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionB",
                table: "Transitions",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");
        }
    }
}

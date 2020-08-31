using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class RegionsTransactions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Regions_RegionA",
                table: "Transitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions");

            migrationBuilder.AlterColumn<string>(
                name: "RegionB",
                table: "Transitions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionA",
                table: "Transitions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegionB",
                table: "Transitions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegionA",
                table: "Transitions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions",
                columns: new[] { "RegionA", "RegionB" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Regions_RegionA",
                table: "Transitions",
                column: "RegionA",
                principalTable: "Regions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

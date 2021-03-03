using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class ChangeMilitaryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Military_MilitaryId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MilitaryId",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "MilitaryId",
                table: "Units",
                type: "nvarchar(41)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MilitaryId",
                table: "Military",
                type: "nvarchar(41)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MilitaryId",
                table: "Units",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(41)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MilitaryId",
                table: "Military",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(41)");

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
    }
}

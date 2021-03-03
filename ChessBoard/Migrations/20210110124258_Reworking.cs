using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class Reworking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalWealth",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Wealth",
                table: "Regions");
            /*
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
            */
            migrationBuilder.AlterColumn<int>(
                name: "Y",
                table: "Military",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "X",
                table: "Military",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Military",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Regions_RegionName",
                table: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Military_RegionName",
                table: "Military");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Military");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<float>(
                name: "NormalWealth",
                table: "Regions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Wealth",
                table: "Regions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "Y",
                table: "Military",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "X",
                table: "Military",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

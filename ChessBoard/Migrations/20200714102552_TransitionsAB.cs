using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class TransitionsAB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "TransitionId",
                table: "Transitions");

            migrationBuilder.AddColumn<string>(
                name: "RegionA",
                table: "Transitions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegionB",
                table: "Transitions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions",
                columns: new[] { "RegionA", "RegionB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "RegionA",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "RegionB",
                table: "Transitions");

            migrationBuilder.AddColumn<int>(
                name: "TransitionId",
                table: "Transitions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions",
                column: "TransitionId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class FactionKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Factions_FactionName",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionName",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_FactionName",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Military_FactionName",
                table: "Military");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "FactionName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FactionName",
                table: "Military");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Factions");

            migrationBuilder.AddColumn<string>(
                name: "FactionId",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactionId",
                table: "Military",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactionId",
                table: "Factions",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
            /*
            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions",
                table: "Factions",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Military_FactionId",
                table: "Military",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Factions_FactionId",
                table: "Military",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Military_Factions_FactionId",
                table: "Military");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_FactionId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Military_FactionId",
                table: "Military");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Military");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Factions");

            migrationBuilder.AddColumn<string>(
                name: "FactionName",
                table: "Units",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactionName",
                table: "Military",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Factions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions",
                table: "Factions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionName",
                table: "Units",
                column: "FactionName");

            migrationBuilder.CreateIndex(
                name: "IX_Military_FactionName",
                table: "Military",
                column: "FactionName");

            migrationBuilder.AddForeignKey(
                name: "FK_Military_Factions_FactionName",
                table: "Military",
                column: "FactionName",
                principalTable: "Factions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionName",
                table: "Units",
                column: "FactionName",
                principalTable: "Factions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

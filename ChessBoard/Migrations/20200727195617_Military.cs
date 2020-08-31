using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessBoard.Migrations
{
    public partial class Military : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MilitaryName",
                table: "Units",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Military",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Type = table.Column<string>(nullable: false),
                    FactionName = table.Column<string>(nullable: true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Besieging = table.Column<string>(nullable: true),
                    Besieged = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Military", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Military_Factions_FactionName",
                        column: x => x.FactionName,
                        principalTable: "Factions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_MilitaryName",
                table: "Units",
                column: "MilitaryName");

            migrationBuilder.CreateIndex(
                name: "IX_Military_FactionName",
                table: "Military",
                column: "FactionName");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Military_MilitaryName",
                table: "Units",
                column: "MilitaryName",
                principalTable: "Military",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Military_MilitaryName",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Military");

            migrationBuilder.DropIndex(
                name: "IX_Units_MilitaryName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MilitaryName",
                table: "Units");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieFitness.Migrations
{
    /// <inheritdoc />
    public partial class ProgramariAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ProgramareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruId = table.Column<int>(type: "int", nullable: false),
                    SesiuneId = table.Column<int>(type: "int", nullable: false),
                    DataProgramarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ProgramareId);
                    table.ForeignKey(
                        name: "FK_Programare_Membru_MembruId",
                        column: x => x.MembruId,
                        principalTable: "Membru",
                        principalColumn: "MembruId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programare_Sesiune_SesiuneId",
                        column: x => x.SesiuneId,
                        principalTable: "Sesiune",
                        principalColumn: "SesiuneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_MembruId",
                table: "Programare",
                column: "MembruId");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_SesiuneId",
                table: "Programare",
                column: "SesiuneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");
        }
    }
}

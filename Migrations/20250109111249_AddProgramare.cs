using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieFitness.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesiune_Antrenor_AntrenorId",
                table: "Sesiune");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesiune_Membru_MembruId",
                table: "Sesiune");

            migrationBuilder.DropIndex(
                name: "IX_Sesiune_AntrenorId",
                table: "Sesiune");

            migrationBuilder.DropIndex(
                name: "IX_Sesiune_MembruId",
                table: "Sesiune");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_AntrenorId",
                table: "Sesiune",
                column: "AntrenorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_MembruId",
                table: "Sesiune",
                column: "MembruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiune_Antrenor_AntrenorId",
                table: "Sesiune",
                column: "AntrenorId",
                principalTable: "Antrenor",
                principalColumn: "AntrenorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiune_Membru_MembruId",
                table: "Sesiune",
                column: "MembruId",
                principalTable: "Membru",
                principalColumn: "MembruId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

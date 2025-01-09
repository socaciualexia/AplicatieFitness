using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieFitness.Migrations
{
    /// <inheritdoc />
    public partial class ProgramareAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Membru_MembruId",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Sesiune_SesiuneId",
                table: "Programare");

            migrationBuilder.RenameColumn(
                name: "SesiuneId",
                table: "Programare",
                newName: "SesiuneID");

            migrationBuilder.RenameColumn(
                name: "MembruId",
                table: "Programare",
                newName: "MembruID");

            migrationBuilder.RenameColumn(
                name: "DataProgramarii",
                table: "Programare",
                newName: "DataProgramare");

            migrationBuilder.RenameColumn(
                name: "ProgramareId",
                table: "Programare",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Programare_SesiuneId",
                table: "Programare",
                newName: "IX_Programare_SesiuneID");

            migrationBuilder.RenameIndex(
                name: "IX_Programare_MembruId",
                table: "Programare",
                newName: "IX_Programare_MembruID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Programare",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Membru_MembruID",
                table: "Programare",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "MembruId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Sesiune_SesiuneID",
                table: "Programare",
                column: "SesiuneID",
                principalTable: "Sesiune",
                principalColumn: "SesiuneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Membru_MembruID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Sesiune_SesiuneID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Programare");

            migrationBuilder.RenameColumn(
                name: "SesiuneID",
                table: "Programare",
                newName: "SesiuneId");

            migrationBuilder.RenameColumn(
                name: "MembruID",
                table: "Programare",
                newName: "MembruId");

            migrationBuilder.RenameColumn(
                name: "DataProgramare",
                table: "Programare",
                newName: "DataProgramarii");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Programare",
                newName: "ProgramareId");

            migrationBuilder.RenameIndex(
                name: "IX_Programare_SesiuneID",
                table: "Programare",
                newName: "IX_Programare_SesiuneId");

            migrationBuilder.RenameIndex(
                name: "IX_Programare_MembruID",
                table: "Programare",
                newName: "IX_Programare_MembruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Membru_MembruId",
                table: "Programare",
                column: "MembruId",
                principalTable: "Membru",
                principalColumn: "MembruId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Sesiune_SesiuneId",
                table: "Programare",
                column: "SesiuneId",
                principalTable: "Sesiune",
                principalColumn: "SesiuneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieFitness.Migrations
{
    public partial class AddAntrenor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenor",
                columns: table => new
                {
                    AntrenorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenor", x => x.AntrenorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antrenor");
        }
    }
}

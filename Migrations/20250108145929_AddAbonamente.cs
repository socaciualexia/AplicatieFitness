using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieFitness.Migrations
{
    public partial class AddAbonamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    AbonamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.AbonamentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonament");
        }
    }
}

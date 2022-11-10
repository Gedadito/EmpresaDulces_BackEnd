using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaDulces.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dulces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDelDulce = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dulces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacionDulces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaDeDulce = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionDulces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasteId = table.Column<int>(type: "int", nullable: false),
                    DulcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sabores_Dulces_DulcesId",
                        column: x => x.DulcesId,
                        principalTable: "Dulces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sabores_DulcesId",
                table: "Sabores",
                column: "DulcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacionDulces");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Dulces");
        }
    }
}

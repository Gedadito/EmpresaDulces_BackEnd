using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaDulces.Migrations
{
    public partial class Dulcezz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dulces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDelDulce = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    MarcaDeDulce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DulceId = table.Column<int>(type: "int", nullable: false),
                    DulcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionDulces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacionDulces_Dulces_DulcesId",
                        column: x => x.DulcesId,
                        principalTable: "Dulces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacionDulces_DulcesId",
                table: "InformacionDulces",
                column: "DulcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacionDulces");

            migrationBuilder.DropTable(
                name: "Dulces");
        }
    }
}

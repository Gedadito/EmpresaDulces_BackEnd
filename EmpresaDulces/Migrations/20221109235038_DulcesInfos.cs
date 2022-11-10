using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaDulces.Migrations
{
    public partial class DulcesInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DulceInfos",
                columns: table => new
                {
                    DulceId = table.Column<int>(type: "int", nullable: false),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    DulcesId = table.Column<int>(type: "int", nullable: true),
                    InformacionDulceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DulceInfos", x => new { x.DulceId, x.InfoId });
                    table.ForeignKey(
                        name: "FK_DulceInfos_Dulces_DulcesId",
                        column: x => x.DulcesId,
                        principalTable: "Dulces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DulceInfos_InformacionDulces_InformacionDulceId",
                        column: x => x.InformacionDulceId,
                        principalTable: "InformacionDulces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DulceInfos_DulcesId",
                table: "DulceInfos",
                column: "DulcesId");

            migrationBuilder.CreateIndex(
                name: "IX_DulceInfos_InformacionDulceId",
                table: "DulceInfos",
                column: "InformacionDulceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DulceInfos");
        }
    }
}

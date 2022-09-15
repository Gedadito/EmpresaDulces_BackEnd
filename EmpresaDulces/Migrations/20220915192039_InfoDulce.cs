using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaDulces.Migrations
{
    public partial class InfoDulce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoDulce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDelDulce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaDeDulce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DulceId = table.Column<int>(type: "int", nullable: false),
                    DulcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoDulce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoDulce_TipoDulce_DulcesId",
                        column: x => x.DulcesId,
                        principalTable: "TipoDulce",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoDulce_DulcesId",
                table: "InfoDulce",
                column: "DulcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoDulce");
        }
    }
}

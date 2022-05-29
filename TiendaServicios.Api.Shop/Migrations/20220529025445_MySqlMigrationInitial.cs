using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicios.Api.Shop.Migrations
{
    public partial class MySqlMigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoSesion",
                columns: table => new
                {
                    PedidoSesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSesion", x => x.PedidoSesionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoSesionDetalle",
                columns: table => new
                {
                    PedidoSesionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductoSelected = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PedidoSesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSesionDetalle", x => x.PedidoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_PedidoSesionDetalle_PedidoSesion_PedidoSesionId",
                        column: x => x.PedidoSesionId,
                        principalTable: "PedidoSesion",
                        principalColumn: "PedidoSesionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSesionDetalle_PedidoSesionId",
                table: "PedidoSesionDetalle",
                column: "PedidoSesionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoSesionDetalle");

            migrationBuilder.DropTable(
                name: "PedidoSesion");
        }
    }
}

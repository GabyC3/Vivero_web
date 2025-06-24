using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivero.BD.Migrations
{
    /// <inheritdoc />
    public partial class tablas4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProductos");

            migrationBuilder.CreateTable(
                name: "gestionProductos",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestionProductos", x => new { x.IdAdministrador, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_gestionProductos_Administradores_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "AdministradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gestionProductos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gestionProductos_IdProducto",
                table: "gestionProductos",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gestionProductos");

            migrationBuilder.CreateTable(
                name: "AdminProductos",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProductos", x => new { x.IdAdministrador, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_AdminProductos_Administradores_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "AdministradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminProductos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminProductos_IdProducto",
                table: "AdminProductos",
                column: "IdProducto");
        }
    }
}

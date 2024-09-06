using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial_1.Migrations
{
    /// <inheritdoc />
    public partial class creacionDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    cantidadPuertas = table.Column<int>(type: "int", nullable: false),
                    marcaID = table.Column<int>(type: "int", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_marcaID",
                        column: x => x.marcaID,
                        principalTable: "Marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolID = table.Column<int>(type: "int", nullable: false),
                    rolesUid = table.Column<int>(type: "int", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_rolesUid",
                        column: x => x.rolesUid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalVenta = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    vehiculoID = table.Column<int>(type: "int", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Vehiculos_vehiculoID",
                        column: x => x.vehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rolesUid",
                table: "Usuarios",
                column: "rolesUid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_marcaID",
                table: "Vehiculos",
                column: "marcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_vehiculoID",
                table: "Ventas",
                column: "vehiculoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}

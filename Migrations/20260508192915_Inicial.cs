using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingExpress.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoVehiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Frecuencia = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoVehiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    TipoVehiculo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Identificacion = table.Column<long>(type: "INTEGER", nullable: false),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ingreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Salida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiculoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TarifaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    EstadoRecibo = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recibos_Tarifas_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreUsuario = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Contrasena = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantePagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReciboId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MetodoComprobanteDePago = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorRecibido = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorDevuelto = table.Column<decimal>(type: "TEXT", nullable: false),
                    EstadoComprobante = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantePagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_Recibos_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Nombre",
                table: "Areas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_PersonaId",
                table: "ComprobantePagos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_ReciboId",
                table: "ComprobantePagos",
                column: "ReciboId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Identificacion",
                table: "Personas",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolId",
                table: "Personas",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_AreaId",
                table: "Recibos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_PersonaId",
                table: "Recibos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_TarifaId",
                table: "Recibos",
                column: "TarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_VehiculoId",
                table: "Recibos",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Nombre",
                table: "Roles",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_Nombre",
                table: "Tarifas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantePagos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

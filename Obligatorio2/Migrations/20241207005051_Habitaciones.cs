using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2.Migrations
{
    public partial class Habitaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 8, 21, 50, 49, 891, DateTimeKind.Local).AddTicks(4931), new DateTime(2024, 12, 6, 21, 50, 49, 891, DateTimeKind.Local).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 9, 21, 50, 49, 891, DateTimeKind.Local).AddTicks(4938), new DateTime(2024, 12, 6, 21, 50, 49, 891, DateTimeKind.Local).AddTicks(4938) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 7, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(37), new DateTime(2024, 12, 5, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 8, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(43), new DateTime(2024, 12, 5, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(42) });
        }
    }
}

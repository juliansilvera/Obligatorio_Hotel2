using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2.Migrations
{
    public partial class AgregarHabitaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 101,
                column: "EstaDisponible",
                value: false);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 103,
                columns: new[] { "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[] { 2, false, 100m, "Simple" });

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 104,
                columns: new[] { "Capacidad", "PrecioDiario", "Tipo" },
                values: new object[] { 4, 150m, "Doble" });

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 105,
                columns: new[] { "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[] { 2, true, 100m, "Simple" });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "Numero", "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[,]
                {
                    { 106, 4, false, 150m, "Doble" },
                    { 107, 2, false, 100m, "Simple" },
                    { 108, 4, true, 150m, "Doble" },
                    { 109, 2, false, 100m, "Simple" },
                    { 110, 4, false, 150m, "Doble" },
                    { 111, 2, true, 100m, "Simple" },
                    { 112, 4, false, 150m, "Doble" },
                    { 113, 2, false, 100m, "Simple" },
                    { 114, 4, true, 150m, "Doble" },
                    { 115, 2, false, 100m, "Simple" },
                    { 116, 4, false, 150m, "Doble" },
                    { 117, 2, true, 100m, "Simple" },
                    { 118, 4, false, 150m, "Doble" },
                    { 119, 2, false, 100m, "Simple" },
                    { 120, 4, true, 150m, "Doble" }
                });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 9, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(399), new DateTime(2024, 12, 7, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2024, 12, 10, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(404), new DateTime(2024, 12, 7, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(404) });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "NumeroReserva", "FechaFin", "FechaInicio", "HuespedId", "NumeroHabitacion" },
                values: new object[] { 3, new DateTime(2024, 12, 11, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(406), new DateTime(2024, 12, 8, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(405), 3, 106 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 106);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 101,
                column: "EstaDisponible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 103,
                columns: new[] { "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[] { 6, true, 200m, "Suite" });

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 104,
                columns: new[] { "Capacidad", "PrecioDiario", "Tipo" },
                values: new object[] { 2, 120m, "Simple" });

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 105,
                columns: new[] { "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[] { 4, false, 180m, "Doble" });

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
    }
}

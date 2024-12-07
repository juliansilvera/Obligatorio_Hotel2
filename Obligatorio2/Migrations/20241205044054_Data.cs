using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "Numero", "Capacidad", "EstaDisponible", "PrecioDiario", "Tipo" },
                values: new object[,]
                {
                    { 101, 2, true, 100m, "Simple" },
                    { 102, 4, true, 150m, "Doble" },
                    { 103, 6, true, 200m, "Suite" },
                    { 104, 2, false, 120m, "Simple" },
                    { 105, 4, false, 180m, "Doble" }
                });

            migrationBuilder.InsertData(
                table: "Huespedes",
                columns: new[] { "Id", "Apellido", "Contraseña", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "Silvera", "juli123", "julianlenna@gmail.com", "Julian" },
                    { 2, "Rodriguez", "carlos123", "crodriguez@ctc.edu.uy", "Carlos" },
                    { 3, "Gonzalez", "maria123", "mariagonzalez@gmail.com", "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "NumeroReserva", "FechaFin", "FechaInicio", "HuespedId", "NumeroHabitacion" },
                values: new object[] { 1, new DateTime(2024, 12, 7, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(37), new DateTime(2024, 12, 5, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(26), 1, 104 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "NumeroReserva", "FechaFin", "FechaInicio", "HuespedId", "NumeroHabitacion" },
                values: new object[] { 2, new DateTime(2024, 12, 8, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(43), new DateTime(2024, 12, 5, 1, 40, 53, 827, DateTimeKind.Local).AddTicks(42), 2, 105 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Huespedes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "NumeroReserva",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Numero",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Huespedes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Huespedes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

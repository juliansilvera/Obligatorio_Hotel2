﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio2.Datos;

#nullable disable

namespace Obligatorio2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241207032023_AgregarHabitaciones")]
    partial class AgregarHabitaciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Huesped", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Huespedes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Silvera",
                            Contraseña = "juli123",
                            Email = "julianlenna@gmail.com",
                            Nombre = "Julian"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Rodriguez",
                            Contraseña = "carlos123",
                            Email = "crodriguez@ctc.edu.uy",
                            Nombre = "Carlos"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Gonzalez",
                            Contraseña = "maria123",
                            Email = "mariagonzalez@gmail.com",
                            Nombre = "Maria"
                        });
                });

            modelBuilder.Entity("Obligatorio2.Modelos.Habitacion", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<bool>("EstaDisponible")
                        .HasColumnType("bit");

                    b.Property<decimal>("PrecioDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.ToTable("Habitaciones");

                    b.HasData(
                        new
                        {
                            Numero = 101,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 102,
                            Capacidad = 4,
                            EstaDisponible = true,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 103,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 104,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 105,
                            Capacidad = 2,
                            EstaDisponible = true,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 106,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 107,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 108,
                            Capacidad = 4,
                            EstaDisponible = true,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 109,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 110,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 111,
                            Capacidad = 2,
                            EstaDisponible = true,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 112,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 113,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 114,
                            Capacidad = 4,
                            EstaDisponible = true,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 115,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 116,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 117,
                            Capacidad = 2,
                            EstaDisponible = true,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 118,
                            Capacidad = 4,
                            EstaDisponible = false,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Numero = 119,
                            Capacidad = 2,
                            EstaDisponible = false,
                            PrecioDiario = 100m,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Numero = 120,
                            Capacidad = 4,
                            EstaDisponible = true,
                            PrecioDiario = 150m,
                            Tipo = "Doble"
                        });
                });

            modelBuilder.Entity("Obligatorio2.Modelos.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumeroReserva")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumeroReserva");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Obligatorio2.Modelos.Reserva", b =>
                {
                    b.Property<int>("NumeroReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroReserva"), 1L, 1);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("HuespedId")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroHabitacion")
                        .HasColumnType("int");

                    b.HasKey("NumeroReserva");

                    b.HasIndex("HuespedId");

                    b.HasIndex("NumeroHabitacion");

                    b.ToTable("Reservas");

                    b.HasData(
                        new
                        {
                            NumeroReserva = 1,
                            FechaFin = new DateTime(2024, 12, 9, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(399),
                            FechaInicio = new DateTime(2024, 12, 7, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(391),
                            HuespedId = 1,
                            NumeroHabitacion = 104
                        },
                        new
                        {
                            NumeroReserva = 2,
                            FechaFin = new DateTime(2024, 12, 10, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(404),
                            FechaInicio = new DateTime(2024, 12, 7, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(404),
                            HuespedId = 2,
                            NumeroHabitacion = 105
                        },
                        new
                        {
                            NumeroReserva = 3,
                            FechaFin = new DateTime(2024, 12, 11, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(406),
                            FechaInicio = new DateTime(2024, 12, 8, 0, 20, 19, 650, DateTimeKind.Local).AddTicks(405),
                            HuespedId = 3,
                            NumeroHabitacion = 106
                        });
                });

            modelBuilder.Entity("Obligatorio2.Modelos.Pago", b =>
                {
                    b.HasOne("Obligatorio2.Modelos.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("NumeroReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Obligatorio2.Modelos.Reserva", b =>
                {
                    b.HasOne("Huesped", "Huesped")
                        .WithMany()
                        .HasForeignKey("HuespedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio2.Modelos.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("NumeroHabitacion")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Habitacion");

                    b.Navigation("Huesped");
                });
#pragma warning restore 612, 618
        }
    }
}

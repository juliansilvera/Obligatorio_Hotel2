using Microsoft.EntityFrameworkCore;
using Obligatorio2.Modelos;

namespace Obligatorio2.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Huesped> Huespedes { get; set; } = null!;
        public DbSet<Habitacion> Habitaciones { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Pago> Pagos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habitacion>()
                .HasKey(h => h.Numero);
            modelBuilder.Entity<Habitacion>()
                .Property(h => h.PrecioDiario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Huesped>()
                .HasKey(h => h.Id);
            modelBuilder.Entity<Huesped>()
                .HasIndex(h => h.Email)
                .IsUnique();

            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.NumeroReserva);
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Huesped)
                .WithMany()
                .HasForeignKey(r => r.HuespedId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Habitacion)
                .WithMany()
                .HasForeignKey(r => r.NumeroHabitacion)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pago>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Reserva)
                .WithMany()
                .HasForeignKey(p => p.NumeroReserva)
                .OnDelete(DeleteBehavior.Cascade);

            InsertarHabitacionesYReservas(modelBuilder);
            InsertarHuespedes(modelBuilder);
        }

        private void InsertarHabitacionesYReservas(ModelBuilder modelBuilder)
        {
            var habitaciones = new List<Habitacion>();
            for (int i = 101; i <= 120; i++)
            {
                habitaciones.Add(new Habitacion
                {
                    Numero = i,
                    Tipo = (i % 2 == 0) ? "Doble" : "Simple",
                    Capacidad = (i % 2 == 0) ? 4 : 2,
                    PrecioDiario = (i % 2 == 0) ? 150 : 100,
                    EstaDisponible = (i % 3 == 0),
                });
            }

            modelBuilder.Entity<Habitacion>().HasData(habitaciones);

            var reservas = new List<Reserva>
            {
                new Reserva { NumeroReserva = 1, NumeroHabitacion = 104, HuespedId = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(2) },
                new Reserva { NumeroReserva = 2, NumeroHabitacion = 105, HuespedId = 2, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(3) },
                new Reserva { NumeroReserva = 3, NumeroHabitacion = 106, HuespedId = 3, FechaInicio = DateTime.Now.AddDays(1), FechaFin = DateTime.Now.AddDays(4) }
            };

            modelBuilder.Entity<Reserva>().HasData(reservas);
        }

        private void InsertarHuespedes(ModelBuilder modelBuilder)
        {
            var huespedes = new List<Huesped>
            {
                new Huesped { Id = 1, Nombre = "Julian", Apellido = "Silvera", Email = "julianlenna@gmail.com", Contraseña = "juli123" },
                new Huesped { Id = 2, Nombre = "Carlos", Apellido = "Rodriguez", Email = "crodriguez@ctc.edu.uy", Contraseña = "carlos123" },
                new Huesped { Id = 3, Nombre = "Maria", Apellido = "Gonzalez", Email = "mariagonzalez@gmail.com", Contraseña = "maria123" }
            };

            modelBuilder.Entity<Huesped>().HasData(huespedes);
        }
    }
}

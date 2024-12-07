using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2.Modelos
{
    public class Reserva
    {
        [Key]
        public int NumeroReserva { get; set; }

        [ForeignKey("Habitacion")]
        public int? NumeroHabitacion { get; set; }
        public Habitacion? Habitacion { get; set; }

        [ForeignKey("Huesped")]
        public int HuespedId { get; set; }
        public Huesped Huesped { get; set; } = null!;

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public Reserva() { }

        public Reserva(int numeroReserva, int? numeroHabitacion, Huesped huesped, DateTime fechaInicio, DateTime fechaFin)
        {
            NumeroReserva = numeroReserva;
            NumeroHabitacion = numeroHabitacion;
            Huesped = huesped;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}

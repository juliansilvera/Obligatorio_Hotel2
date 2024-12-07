using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2.Modelos
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Reserva")]
        public int NumeroReserva { get; set; }
        public Reserva Reserva { get; set; } = null!;

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        public Pago() { }

        public Pago(int id, int numeroReserva, decimal monto, DateTime fechaPago)
        {
            Id = id;
            NumeroReserva = numeroReserva;
            Monto = monto;
            FechaPago = fechaPago;
        }
    }
}

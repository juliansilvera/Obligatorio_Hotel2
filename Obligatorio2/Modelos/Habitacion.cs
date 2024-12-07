using System.ComponentModel.DataAnnotations;

namespace Obligatorio2.Modelos
{
    public class Habitacion
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        public int Capacidad { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioDiario { get; set; }

        public bool EstaDisponible { get; set; } = true;

        public Habitacion()
        {
        }

        public Habitacion(int numero, string tipo, int capacidad, decimal precioDiario)
        {
            Numero = numero;
            Tipo = tipo;
            Capacidad = capacidad;
            PrecioDiario = precioDiario;
            EstaDisponible = true;
        }
    }
}

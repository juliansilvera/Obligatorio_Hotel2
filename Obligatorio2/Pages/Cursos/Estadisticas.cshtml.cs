using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;
using System.Linq;

namespace Obligatorio2.Pages.Cursos
{
    public class EstadisticasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EstadisticasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string? HabitacionConMasReservas { get; set; }
        public int TotalReservas { get; set; }

        public void OnGet()
        {
            var reservaPorHabitacion = _context.Reservas
                .GroupBy(r => r.NumeroHabitacion)
                .Select(group => new { Habitacion = group.Key, Count = group.Count() })
                .OrderByDescending(g => g.Count)
                .FirstOrDefault();

            if (reservaPorHabitacion != null)
            {
                var habitacion = _context.Habitaciones
                    .FirstOrDefault(h => h.Numero == reservaPorHabitacion.Habitacion);

                if (habitacion != null)
                {
                    HabitacionConMasReservas = $"Habitación {habitacion.Numero} ({habitacion.Tipo})";
                    TotalReservas = reservaPorHabitacion.Count;
                }
                else
                {
                    HabitacionConMasReservas = "Habitación no encontrada";
                    TotalReservas = 0;
                }
            }
            else
            {
                HabitacionConMasReservas = "No hay reservas registradas";
                TotalReservas = 0;
            }
        }
    }
}

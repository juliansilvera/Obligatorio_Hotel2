using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Modelos;
using Obligatorio2.Datos;

namespace Obligatorio2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Habitacion> HabitacionesDisponibles { get; set; } = new List<Habitacion>();

        public void OnGet()
        {
            _logger.LogInformation("OnGet ejecutado en IndexModel.");

            try
            {
                HabitacionesDisponibles = _context.Habitaciones?
                                                   .Where(h => h.EstaDisponible)
                                                   .ToList() ?? new List<Habitacion>();

                if (!HabitacionesDisponibles.Any())
                {
                    _logger.LogWarning("No se encontraron habitaciones disponibles en la base de datos.");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error al obtener habitaciones disponibles: {ex.Message}");

                HabitacionesDisponibles = new List<Habitacion>
                {
                    new() { Numero = 101, Tipo = "Simple", Capacidad = 2, PrecioDiario = 100 },
                    new() { Numero = 102, Tipo = "Doble", Capacidad = 4, PrecioDiario = 150 }
                };
            }
        }
    }
}

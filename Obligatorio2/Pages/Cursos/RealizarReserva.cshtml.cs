using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;

namespace Obligatorio2.Pages.Cursos
{
    public class RealizarReservaModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly Huesped huesped;
        public RealizarReservaModel(ApplicationDbContext context, Huesped huesped)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this.huesped = huesped ?? throw new ArgumentNullException(nameof(huesped));
        }

        [BindProperty]
        public int HabitacionId { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        public IActionResult OnGet(int habitacionId)
        {
            HabitacionId = habitacionId;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HabitacionId <= 0)
            {
                ErrorMessage = "Id de habitación inválido.";
                return Page();
            }

            var habitacion = _context.Habitaciones.FirstOrDefault(h => h.Numero == HabitacionId);
            if (habitacion == null)
            {
                ErrorMessage = "La habitación no existe.";
                return Page();
            }

            if (!habitacion.EstaDisponible)
            {
                ErrorMessage = "La habitación no está disponible.";
                return Page();
            }

            var reserva = new Reserva(
                numeroReserva: new Random().Next(1000, 9999),
                numeroHabitacion: HabitacionId,
                huesped: huesped,
                fechaInicio: DateTime.Now,
                fechaFin: DateTime.Now.AddDays(1)
            );

            _context.Reservas.Add(reserva);
            habitacion.EstaDisponible = false;
            _context.SaveChanges();

            return RedirectToPage("/Cursos/MisReservas");
        }
    }
}

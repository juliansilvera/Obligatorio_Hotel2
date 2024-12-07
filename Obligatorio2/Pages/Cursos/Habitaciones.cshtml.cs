using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;
using System.Linq;

namespace Obligatorio2.Pages.Cursos
{
    public class HabitacionesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HabitacionesModel(ApplicationDbContext context)
        {
            _context = context;
            HabitacionesDisponibles = new List<Habitacion>();
        }

        public List<Habitacion> HabitacionesDisponibles { get; set; }

        public void OnGet()
        {
            HabitacionesDisponibles = _context.Habitaciones
                .Where(h => h.EstaDisponible)
                .ToList();
        }

        public IActionResult OnPostReservar(int numeroHabitacion)
        {
            string? usuarioIdStr = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioIdStr))
            {
                TempData["ErrorMessage"] = "Debes iniciar sesión para realizar una reserva.";
                return RedirectToPage("/Cursos/Login", new { redirectFrom = "Habitaciones" });
            }

            int usuarioId;
            try
            {
                usuarioId = int.Parse(usuarioIdStr);
            }
            catch (FormatException)
            {
                TempData["ErrorMessage"] = "Hubo un problema con tu sesión. Por favor, inicia sesión nuevamente.";
                return RedirectToPage("/Cursos/Login");
            }

            var habitacion = _context.Habitaciones.FirstOrDefault(h => h.Numero == numeroHabitacion && h.EstaDisponible);
            if (habitacion == null)
            {
                ModelState.AddModelError(string.Empty, "La habitación seleccionada no está disponible.");
                return Page();
            }

            var nuevaReserva = new Reserva
            {
                NumeroHabitacion = numeroHabitacion,
                HuespedId = usuarioId,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(1) 
            };

            habitacion.EstaDisponible = false;

            try
            {
                _context.Reservas.Add(nuevaReserva);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error al realizar la reserva: {ex.Message}");
                return Page();
            }

            TempData["SuccessMessage"] = "¡Reserva realizada con éxito!";
            return RedirectToPage("/Cursos/MisReservas");
        }
    }
}

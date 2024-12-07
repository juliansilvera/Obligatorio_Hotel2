using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Modelos;
using Obligatorio2.Datos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Obligatorio2.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        public Huesped NuevoHuesped { get; set; } = new();

        [BindProperty]
        public string ForgotEmail { get; set; } = string.Empty;

        public List<Habitacion> HabitacionesDisponibles { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            HabitacionesDisponibles = _context.Habitaciones.Where(h => h.EstaDisponible).ToList();
        }

        public IActionResult OnPostLogin()
        {
            var huesped = _context.Huespedes.FirstOrDefault(h => h.Email == Email && h.Contraseña == Password);
            if (huesped != null)
            {
                return RedirectToPage("Habitaciones");
            }

            ModelState.AddModelError("LoginErrors", "Email o contraseña incorrectos.");
            return Page();
        }

        public IActionResult OnPostRegister()
        {
            if (!_context.Huespedes.Any(h => h.Email == NuevoHuesped.Email))
            {
                _context.Huespedes.Add(NuevoHuesped);
                _context.SaveChanges();
                return RedirectToPage("Habitaciones");
            }

            ModelState.AddModelError("RegisterErrors", "El email ya está registrado.");
            return Page();
        }

        public IActionResult OnPostForgotPassword()
        {
            var huesped = _context.Huespedes.FirstOrDefault(h => h.Email == ForgotEmail);
            if (huesped != null)
            {
                ViewData["PasswordMessage"] = $"Tu contraseña es: {huesped.Contraseña}";
            }
            else
            {
                ModelState.AddModelError("ForgotPasswordErrors", "El email no está registrado.");
            }

            return Page();
        }
    }
}

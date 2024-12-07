using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;
using System.Linq;

namespace Obligatorio2.Pages.Cursos
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(Request.Query["redirectFrom"]))
            {
                TempData["ErrorMessage"] = "Por favor, inicia sesión para realizar una reserva.";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var usuario = _context.Huespedes.FirstOrDefault(u => u.Email == Email && u.Contraseña == Password);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas. Por favor, intenta de nuevo.");
                return Page();
            }

            HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
            TempData["SuccessMessage"] = "Sesión iniciada con éxito.";
            return RedirectToPage("/Cursos/Habitaciones");
        }
    }
}

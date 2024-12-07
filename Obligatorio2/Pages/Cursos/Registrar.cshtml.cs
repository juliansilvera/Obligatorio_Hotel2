using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;

namespace Obligatorio2.Pages.Cursos
{
    public class RegistrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegistrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Nombre { get; set; } = string.Empty;

        [BindProperty]
        public string Apellido { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Contrase�a { get; set; } = string.Empty;

        public string? Mensaje { get; set; }

        public IActionResult OnPostRegister()
        {
            if (_context.Huespedes.Any(h => h.Email == Email))
            {
                Mensaje = "El email ya est� registrado.";
                return Page();
            }

            var nuevoHuesped = new Huesped
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Email = Email,
                Contrase�a = Contrase�a
            };

            _context.Huespedes.Add(nuevoHuesped);
            _context.SaveChanges();

            return RedirectToPage("/Cursos/Login");
        }
    }
}

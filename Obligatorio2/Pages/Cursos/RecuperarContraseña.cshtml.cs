using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2.Datos;
using System.Linq;

namespace Obligatorio2.Pages.Cursos
{
    public class RecuperarContrase�aModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RecuperarContrase�aModel(ApplicationDbContext context)
        {
            _context = context;
            Email = string.Empty;
            Mensaje = string.Empty;
        }

        [BindProperty]
        public string Email { get; set; }
        public string Mensaje { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var usuario = _context.Huespedes.FirstOrDefault(u => u.Email == Email);

            if (usuario != null)
            {
                Mensaje = $"Tu contrase�a es: {usuario.Contrase�a}";
            }
            else
            {
                Mensaje = "No se encontr� un usuario con ese correo electr�nico.";
            }

            return Page();
        }
    }
}

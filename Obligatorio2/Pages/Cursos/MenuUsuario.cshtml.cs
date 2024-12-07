using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Obligatorio2.Modelos;
using Obligatorio2.Datos;

namespace Obligatorio2.Pages.Cursos
{
    public class MenuUsuario : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MenuUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public Huesped? Usuario { get; set; }

        public void OnGet()
        {
            string? usuarioIdStr = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioIdStr))
            {
                Response.Redirect("/Login");
                return;
            }

            int usuarioId;
            try
            {
                usuarioId = int.Parse(usuarioIdStr);
            }
            catch (FormatException)
            {
                Response.Redirect("/Login");
                return;
            }

            Usuario = _context.Huespedes.FirstOrDefault(h => h.Id == usuarioId);

            if (Usuario == null)
            {
                Response.Redirect("/Login");
            }
        }
    }
}

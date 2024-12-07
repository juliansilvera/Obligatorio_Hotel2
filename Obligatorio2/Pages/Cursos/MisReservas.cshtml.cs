using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Obligatorio2.Pages.Cursos
{
    public class MisReservasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public MisReservasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var usuarioIdStr = HttpContext.Session.GetString("UsuarioId");
            if (string.IsNullOrEmpty(usuarioIdStr))
            {
                Response.Redirect("/Cursos/Login");
                return;
            }

            int usuarioId = int.Parse(usuarioIdStr);
            Reservas = _context.Reservas
                .Where(r => r.HuespedId == usuarioId)
                .Include(r => r.Habitacion)
                .ToList();
        }

        public IActionResult OnPostEditar(int id, DateTime nuevaFechaInicio, DateTime nuevaFechaFin)
        {
            if (nuevaFechaInicio < DateTime.Now.Date)
            {
                ModelState.AddModelError(string.Empty, "La fecha de inicio no puede ser anterior a hoy.");
                return Page();
            }

            if (nuevaFechaFin <= nuevaFechaInicio)
            {
                ModelState.AddModelError(string.Empty, "La fecha de fin debe ser posterior a la fecha de inicio.");
                return Page();
            }

            var reserva = _context.Reservas.FirstOrDefault(r => r.NumeroReserva == id);
            if (reserva != null)
            {
                reserva.FechaInicio = nuevaFechaInicio;
                reserva.FechaFin = nuevaFechaFin;
                _context.SaveChanges();
            }

            TempData["Mensaje"] = "Reserva actualizada exitosamente.";
            return RedirectToPage();
        }

        public IActionResult OnPostCancelar(int id)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.NumeroReserva == id);
            if (reserva != null)
            {
                var habitacion = _context.Habitaciones.FirstOrDefault(h => h.Numero == reserva.NumeroHabitacion);
                if (habitacion != null)
                {
                    habitacion.EstaDisponible = true;
                }

                _context.Reservas.Remove(reserva);
                _context.SaveChanges();

                TempData["Mensaje"] = "Reserva cancelada exitosamente.";
            }

            return RedirectToPage();
        }
    }
}

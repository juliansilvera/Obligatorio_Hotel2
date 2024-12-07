using Microsoft.EntityFrameworkCore;
using Obligatorio2.Datos;
using Obligatorio2.Modelos;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        logger.LogInformation("Aplicando migraciones...");
        context.Database.Migrate();
        logger.LogInformation("Migraciones aplicadas correctamente.");
        InicializarDatos(context, logger);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error al aplicar migraciones o inicializar datos.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();
app.MapGet("/", () => Results.Redirect("/Cursos/Index"));

app.Run();

void InicializarDatos(ApplicationDbContext context, ILogger logger)
{
    if (!context.Habitaciones.Any())
    {
        logger.LogInformation("Cargando habitaciones iniciales...");

        var habitaciones = new List<Habitacion>();
        for (int i = 101; i <= 120; i++)
        {
            habitaciones.Add(new Habitacion
            {
                Numero = i,
                Tipo = (i % 2 == 0) ? "Doble" : "Simple",
                Capacidad = (i % 2 == 0) ? 4 : 2,
                PrecioDiario = (i % 2 == 0) ? 150 : 100,
                EstaDisponible = (i % 3 != 0),
            });
        }

        context.Habitaciones.AddRange(habitaciones);
        context.SaveChanges();
        logger.LogInformation("Habitaciones iniciales cargadas.");
    }

    if (!context.Reservas.Any())
    {
        logger.LogInformation("Cargando reservas iniciales...");

        var reservas = new List<Reserva>
        {
            new() { NumeroHabitacion = 102, HuespedId = 1, FechaInicio = DateTime.Now.AddDays(-3), FechaFin = DateTime.Now.AddDays(2) },
            new() { NumeroHabitacion = 105, HuespedId = 2, FechaInicio = DateTime.Now.AddDays(-1), FechaFin = DateTime.Now.AddDays(4) },
            new() { NumeroHabitacion = 108, HuespedId = 3, FechaInicio = DateTime.Now.AddDays(-5), FechaFin = DateTime.Now.AddDays(1) },
            new() { NumeroHabitacion = 112, HuespedId = 1, FechaInicio = DateTime.Now.AddDays(-2), FechaFin = DateTime.Now.AddDays(3) },
            new() { NumeroHabitacion = 118, HuespedId = 2, FechaInicio = DateTime.Now.AddDays(-1), FechaFin = DateTime.Now.AddDays(1) }
        };

        context.Reservas.AddRange(reservas);
        context.SaveChanges();

        foreach (var reserva in reservas)
        {
            var habitacion = context.Habitaciones.FirstOrDefault(h => h.Numero == reserva.NumeroHabitacion);
            if (habitacion != null)
            {
                habitacion.EstaDisponible = false;
            }
        }

        context.SaveChanges();
        logger.LogInformation("Reservas iniciales cargadas.");
    }

    if (!context.Huespedes.Any())
    {
        logger.LogInformation("Cargando huéspedes iniciales...");
        var huespedes = new List<Huesped>
        {
            new() { Id = 1, Nombre = "Julian", Apellido = "Silvera", Email = "julianlenna@gmail.com", Contraseña = "juli123" },
            new() { Id = 2, Nombre = "Carlos", Apellido = "Rodriguez", Email = "crodriguez@ctc.edu.uy", Contraseña = "carlos123" },
            new() { Id = 3, Nombre = "Maria", Apellido = "Gonzalez", Email = "mariagonzalez@gmail.com", Contraseña = "maria123" }
        };

        context.Huespedes.AddRange(huespedes);
        context.SaveChanges();
        logger.LogInformation("Huéspedes iniciales cargados.");
    }
}

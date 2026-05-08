using Microsoft.EntityFrameworkCore;
using ParkingExpress.Models;

namespace ParkingExpress.Data;

public static class DbInitializer
{
    public static void Initializer(AppDbContext appDbContext)
    {
        appDbContext.Database.Migrate();

        if (appDbContext.Usuarios.Any(usuario => usuario.NombreUsuario == "Administrador"))
        {
            return;
        }

        Rol rolAdministrador = new Rol(
            "Administrador",
            "Sistema"
        );
        Persona personaAdministrador = new Persona(
            "Administrador",
            1111111111,
            rolAdministrador,
            "Sistema"
        );
        Usuario usuarioAdministrador = new Usuario(
            personaAdministrador,
            "Administrador",
            "ParkingExpress2026",
            "Sistema"
        );

        appDbContext.Usuarios.Add(usuarioAdministrador);
        appDbContext.SaveChanges();
    }
}
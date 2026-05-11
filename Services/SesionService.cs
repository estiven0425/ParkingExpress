using Microsoft.EntityFrameworkCore;
using ParkingExpress.Data;
using ParkingExpress.Models;

namespace ParkingExpress.Services;

public static class SesionService
{
    public static Usuario? UsuarioActual { get; private set; }

    public static void IniciarSesion(string nombreUsuario, string contrasena)
    {
        using AppDbContext appDbContext = new AppDbContext();

        CerrarSesion();

        Usuario? usuarioEncontrado = appDbContext.Usuarios.Include(usuario => usuario.Persona).FirstOrDefault(usuario => usuario.NombreUsuario == nombreUsuario);

        if (usuarioEncontrado is not null && SeguridadService.VerificarContrasena(contrasena, usuarioEncontrado.Contrasena))
        {
            UsuarioActual = usuarioEncontrado;
        }
        else
        {
            throw new UnauthorizedAccessException("Usuario o contraseña incorrecta.");
        }
    }

    public static void CerrarSesion()
    {
        UsuarioActual = null;
    }
}
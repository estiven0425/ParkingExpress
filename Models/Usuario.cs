using System.ComponentModel.DataAnnotations;
using ParkingExpress.Services;

namespace ParkingExpress.Models;

public class Usuario : Base
{
    public int PersonaId { get; private set; }
    public Persona Persona { get; private set; } = null!;

    [MaxLength(255)]
    public string NombreUsuario { get; private set; } = string.Empty;
    [MaxLength(500)]
    public string Contrasena { get; private set; } = string.Empty;
    
    private Usuario()
    {}

    public Usuario(Persona persona, string nombreUsuario, string contrasena, string creadoPor)
    {
        Persona = persona ??  throw new ArgumentNullException(nameof(persona), "La persona asociada no puede estar vacía");
        NombreUsuario = string.IsNullOrEmpty(nombreUsuario)
            ? throw new ArgumentNullException(nameof(nombreUsuario), "El nombre de usuario no puede estar vacío.")
            : nombreUsuario;
        Contrasena = contrasena.Length < 10
                ? throw new ArgumentOutOfRangeException(nameof(contrasena), "La contraseña debe tener mínimo 10 caracteres.")
                : Seguridad.EncriptarContrasena(contrasena);
        
        RegistrarCreacion(creadoPor);
    }

    public void ModificarUsuario(Persona persona, string nombreUsuario,string modificadoPor)
    {
        Persona = persona ??  throw new ArgumentNullException(nameof(persona), "La persona asociada no puede estar vacía");
        NombreUsuario = string.IsNullOrEmpty(nombreUsuario)
            ? throw new ArgumentNullException(nameof(nombreUsuario), "El nombre de usuario no puede estar vacío.")
            : nombreUsuario;

        RegistrarModificacion(modificadoPor);
    }

    public void ModificarContrasena(string contrasenaNueva, string contrasenaActual, string contrasenaAlmacenada,
        string modificadoPor)
    {
        Contrasena = contrasenaNueva.Length < 10
            ? throw new ArgumentOutOfRangeException(nameof(contrasenaNueva), "La contraseña debe tener mínimo 10 caracteres.")
            : Seguridad.CambiarContrasena(contrasenaNueva, contrasenaActual, contrasenaAlmacenada);
        
        RegistrarModificacion(modificadoPor);
    }
}
using System.ComponentModel.DataAnnotations;

namespace ParkingExpress.Models;

public class Rol : Base
{
    [MaxLength(255)]
    public string Nombre { get; private set; } = string.Empty;

    public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    
    private Rol()
    {}

    public Rol(string nombre, string creadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre del rol no puede estar vacío.")
            : nombre;
        
        RegistrarCreacion(creadoPor);
    }

    public void ModificarRol(string nombre, string modificadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre del rol no puede estar vacío.")
            : nombre;
        
        RegistrarModificacion(modificadoPor);
    }
}
namespace ParkingExpress.Models;

public class Rol : Base
{
    public string? Nombre { get; private set; }

    public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    
    public Rol()
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
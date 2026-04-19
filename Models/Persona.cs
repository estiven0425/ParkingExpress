namespace ParkingExpress.Models;

public class Persona : Base
{
    public string Nombre { get; private set; }
    public long Identificacion { get; private set; }
    
    public int RolId { get; private set; }
    public Rol Rol { get; private set; }
    
    public Persona()
    {}

    public Persona(string nombre, long identificacion, Rol rol, string creadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre de la persona no puede estar vacío.")
            : nombre;
        Identificacion = identificacion is > 0 and <= 9999999999
            ? identificacion
            : throw new ArgumentOutOfRangeException(nameof(identificacion), identificacion, "El número de identificación no es válido.");
        Rol = rol ?? throw new ArgumentNullException(nameof(rol), "El rol no puede estar vacío.");
        
        RegistrarCreacion(creadoPor);
    }
    
    public void ModificarPersona(string nombre, long identificacion, Rol rol, string modificadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre de la persona no puede estar vacío.")
            : nombre;
        Identificacion = identificacion is > 0 and <= 9999999999
            ? identificacion
            : throw new ArgumentOutOfRangeException(nameof(identificacion), identificacion, "El número de identificación no es válido.");
        Rol = rol ?? throw new ArgumentNullException(nameof(rol), "El rol no puede estar vacío.");
        
        RegistrarModificacion(modificadoPor);
    }
}
using System.ComponentModel.DataAnnotations;

namespace ParkingExpress.Models;

public class Persona : Base
{
    [MaxLength(255)]
    public string Nombre { get; private set; } = string.Empty;
    public long Identificacion { get; private set; }
    
    public int RolId { get; private set; }
    public Rol Rol { get; private set; } = null!;

    public ICollection<Recibo> Recibos { get; set; } =  new List<Recibo>();
    
    private Persona()
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
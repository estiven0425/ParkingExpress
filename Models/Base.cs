using System.ComponentModel.DataAnnotations;

namespace ParkingExpress.Models;

public abstract class Base
{
    public int Id { get; init; }
    public bool Eliminado { get; private set; }
    
    public DateTime CreadoEn { get; private set; }
    [MaxLength(255)]
    public string CreadoPor { get; private set; } = string.Empty;
        
    public DateTime? ModificadoEn { get; private set; }
    [MaxLength(255)]
    public string? ModificadoPor { get; private set; }

    protected void RegistrarCreacion(string creadoPor)
    {
        CreadoEn = DateTime.Now;
        CreadoPor = string.IsNullOrEmpty(creadoPor)
            ? throw new ArgumentNullException(nameof(creadoPor), "La auditoría no puede ser nula")
            : creadoPor;
    }

    protected void RegistrarModificacion(string modificadoPor)
    {
        ModificadoEn = DateTime.Now;
        ModificadoPor = string.IsNullOrEmpty(modificadoPor)
            ? throw new ArgumentNullException(nameof(modificadoPor), "La auditoría no puede ser nula")
            : modificadoPor;
    }
    
    public void AlternarEliminacion()
    {
        Eliminado = !Eliminado;
    }
}
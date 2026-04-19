namespace ParkingExpress.Models;

public abstract class Base
{
    public int  Id { get; init; }
    private bool Eliminado { get; set; }
    
    public DateTime CreadoEn { get; private set; }
    
    private string _creadoPor = string.Empty;
    public string CreadoPor
    {
        get => _creadoPor;
        private set => _creadoPor = string.IsNullOrEmpty(value)
            ? throw new ArgumentNullException(nameof(value), "La auditoría no puede ser nula")
            : value;
    }
        
    public DateTime? ModificadoEn { get; private set; }
    
    private string? _modificadoPor;
    public string? ModificadoPor
    {
        get => _modificadoPor;
        private set => _modificadoPor = string.IsNullOrEmpty(value)
            ? throw new ArgumentNullException(nameof(value), "La auditoría no puede ser nula")
            : value;
    }

    protected void RegistrarCreacion(string creadoPor)
    {
        CreadoEn = DateTime.Now;
        CreadoPor = creadoPor;
    }

    protected void RegistrarModificacion(string modificadoPor)
    {
        ModificadoEn = DateTime.Now;
        ModificadoPor = modificadoPor;
    }
    
    public void AlternarEliminacion()
    {
        Eliminado = !Eliminado;
    }

    public bool EstadoEliminado()
    {
        return Eliminado;
    }
}
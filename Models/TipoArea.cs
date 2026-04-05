using ParkingExpress.Models.Enums;
using ParkingExpress.Helpers;

namespace ParkingExpress.Models;

public abstract class TipoArea
{
    public int Id { get; set; }
    public bool Techo { get; set; }

    private int _planta;
    public int Planta
    {
        get => _planta;
        set =>
            _planta = Validaciones.EsCero(value)
                ? throw new ArgumentOutOfRangeException(nameof(value), value, "No se puede asignar el 0 como planta.")
                : _planta = value;
    }
    
    public Acceso Acceso { get; set; }
    public Soporte Soporte { get; set; }
    public bool Vigilancia { get; set; }
    public bool Estado { get; set; }
}
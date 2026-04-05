using ParkingExpress.Helpers;

namespace ParkingExpress.Models;

public class AreaVehicular : TipoArea
{
    private int _capacidad;
    public int Capacidad
    {
        get => _capacidad;
        set =>
            _capacidad = Validaciones.EsMenorQueCero(value)
                ? throw new ArgumentOutOfRangeException(nameof(value), value, "La capacidad del área no puede ser menor a 0.")
                : _capacidad = value;
    }
    
    public bool Membresia { get; set; }
}
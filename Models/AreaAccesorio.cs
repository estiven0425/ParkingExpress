using ParkingExpress.Helpers;

namespace ParkingExpress.Models;

public class AreaAccesorio : TipoArea
{
    private string _nombre = string.Empty;
    public string Nombre
    {
        get => _nombre;
        set =>
            _nombre = Validaciones.EsVacioONulo(value)
            ? throw new ArgumentNullException(nameof(value), "El nombre del área no puede ser vacio.")
            : _nombre = value;
    }
    
    private int _capacidad;
    public int Capacidad
    {
        get => _capacidad;
        set =>
            _capacidad = Validaciones.EsMenorQueCero(value)
                ? throw new ArgumentOutOfRangeException(nameof(value), value, "La capacidad del área no puede ser menor a 0.")
                : _capacidad = value;
    }
    
    public bool Seguridad { get; set; }
}
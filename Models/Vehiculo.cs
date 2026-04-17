using ParkingExpress.Helpers;
using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Vehiculo
{
    protected int Id { get; set; }
    
    private string _placa = string.Empty;
    public string Placa
    {
        get => _placa;
        set =>
            _placa = Validaciones.EsVacioONulo(value)
                ? throw new ArgumentNullException(nameof(value), "La placa del vehículo no puede estar vacía.")
                : _placa = value;
    }
    
    private string _marca = string.Empty;
    public string Marca
    {
        get => _marca;
        set =>
            _marca = Validaciones.EsVacioONulo(value)
                ? throw new ArgumentNullException(nameof(value), "La marca del vehículo no puede estar vacía.")
                : _marca = value;
    }
    
    private string _color = string.Empty;
    public string Color
    {
        get => _color;
        set =>
            _color = Validaciones.EsVacioONulo(value)
                ? throw new ArgumentNullException(nameof(value), "El color del vehículo no puede estar vacío.")
                : _color = value;
    }
    
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    
    public Estado  Estado { get; set; }
    
    protected Vehiculo()
    {}
    
    public Vehiculo(string placa, string marca, string color, Estado estado)
    {
        Placa = placa;
        Marca = marca;
        Color = color;
        Estado = estado;
    }
}
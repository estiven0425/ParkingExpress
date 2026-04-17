using ParkingExpress.Helpers;
using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Tarifa
{
    protected int Id { get; set; }
    
    private string _nombre = string.Empty;
    public string Nombre
    {
        get => _nombre;
        set =>
            _nombre = Validaciones.EsVacioONulo(value)
                ? throw new ArgumentNullException(nameof(value), "El nombre de la tarifa no puede ser vacio.")
                : _nombre = value;
    }
    
    private int _valor;
    public int Valor
    {
        get => _valor;
        set =>
            _valor = Validaciones.EsMenorQueCero(value)
                ? throw new ArgumentOutOfRangeException(nameof(value), value, "El valor no puede ser menor a 0.")
                : _valor = value;
    }
    
    public Cobro Cobro { get; set; }
    
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    
    public Estado Estado { get; set; }
    
    protected Tarifa()
    {}
    
    public Tarifa(int valor, string nombre, Cobro cobro, Estado estado)
    {
        Nombre = nombre;
        Valor = valor;
        Cobro = cobro;
        Estado = estado;
    }
}
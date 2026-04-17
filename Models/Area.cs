using ParkingExpress.Models.Enums;
using ParkingExpress.Helpers;

namespace ParkingExpress.Models;

public class Area
{
    protected int Id { get; set; }
    
    private string _nombre = string.Empty;
    public string Nombre
    {
        get => _nombre;
        set =>
            _nombre = Validaciones.EsVacioONulo(value)
                ? throw new ArgumentNullException(nameof(value), "El nombre del área no puede ser vacío.")
                : _nombre = value;
    }

    private int _planta;
    public int Planta
    {
        get => _planta;
        set =>
            _planta = Validaciones.EsCero(value)
                ? throw new ArgumentOutOfRangeException(nameof(value), value, "No se puede asignar el 0 como planta.")
                : _planta = value;
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
    
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    
    public Acceso Acceso { get; set; }
    public Soporte Soporte { get; set; }
    public Estado Estado { get; set; }

    protected Area()
    {}
    
    public Area(string nombre, int planta, int capacidad, Acceso acceso, Soporte soporte, Estado estado)
    {
        Nombre = nombre;
        Planta = planta;
        Capacidad = capacidad;
        Acceso = acceso;
        Soporte = soporte;
        Estado = estado;
    }

    public int Disponibilidad()
    {
        int cantidad = Capacidad;
            
        foreach (Ticket ticket in Tickets)
        {
            if (!ticket.Salida.HasValue)
            {
                --cantidad;
            }
        }

        return cantidad;
    }
}
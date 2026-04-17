using ParkingExpress.Helpers;
using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Ticket
{
    protected int Id { get; set; }
    
    protected int VehiculoId { get; set; }
    public Vehiculo? Vehiculo { get; set; }
    
    public DateTime Ingreso { get; set; }
    
    private DateTime? _salida;
    public DateTime? Salida
    {
        get => _salida ?? throw new ArgumentNullException(nameof(_salida), "No se ha asignado una fecha de salida.");
        private set =>
            _salida = DateTime.Compare(Convert.ToDateTime(value), Ingreso) > 0
            ? _salida = value
            : throw new ArgumentOutOfRangeException(nameof(value), value, "La salida no puede ser antes del ingreso.");
    }
    
    protected int AreaId { get; set; }
    public Area? Area { get; set; }
    
    protected int TarifaId { get; set; }
    public Tarifa? Tarifa { get; set; }

    private decimal? _costo;
    public decimal Costo
    {
        get => _costo ?? 0;
        private set =>
            _costo = Salida.HasValue
                ? Validaciones.EsMenorQueCero(Decimal.ToInt32(value))
                    ? throw new ArgumentOutOfRangeException(nameof(value), value, "El costo no puede ser menor a 0.")
                    : _costo = value
                : throw new ArgumentNullException(nameof(value), "No se puede ingresar un costo sin hora de salida.");
    }
    public Estado Estado { get; set; }
    
    protected Ticket()
    {}
    
    public Ticket(Vehiculo vehiculo, DateTime ingreso, Area area, Tarifa tarifa, Estado estado)
    {
        Vehiculo = vehiculo;
        Ingreso = ingreso;
        Area = area;
        Tarifa = tarifa;
        Estado = estado;
    }
    
    public Ticket(int vehiculoId, DateTime ingreso, int areaId, int tarifaId, Estado estado)
    {
        VehiculoId = vehiculoId;
        Ingreso = ingreso;
        AreaId = areaId;
        TarifaId = tarifaId;
        Estado = estado;
    }

    public void Salir(DateTime salida)
    {
        Salida = salida;

        TimeSpan? tiempo = Salida - Ingreso;

        if (Tarifa.Cobro.Equals(Cobro.Hora))
        {
            Costo = Tarifa.Valor * Convert.ToDecimal(tiempo.Value.TotalHours);
        }
        else if (Tarifa.Cobro.Equals(Cobro.Dia))
        {
            Costo = Tarifa.Valor * Convert.ToDecimal(tiempo.Value.TotalDays);
        }
    }
}
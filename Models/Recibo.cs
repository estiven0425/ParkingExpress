using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Recibo : Base
{
    public DateTime Ingreso { get; private set; }
    public DateTime? Salida { get; private set; }

    public int AreaId { get; private set; }
    public Area Area { get; private set; }

    public Vehiculo Vehiculo { get; private set; }

    public int TarifaId { get; private set; }
    public Tarifa Tarifa { get; private set; }

    public decimal Total { get; private set; }

    public EstadoRecibo EstadoRecibo { get; private set; }

    private Recibo()
    {}

    public Recibo(DateTime ingreso, Area area, Vehiculo vehiculo, Tarifa tarifa, string creadoPor)
    {
        Ingreso = ingreso;
        Area = area ?? throw new ArgumentNullException(nameof(area), "El área del recibo no puede estar vacío.");
        Vehiculo = vehiculo ?? throw new ArgumentNullException(nameof(vehiculo), "El vehículo del recibo no puede estar vacío.");
        Tarifa = tarifa ?? throw new ArgumentNullException(nameof(tarifa), "La tarifa del recibo no puede estar vacía.");
        EstadoRecibo = EstadoRecibo.Abierto;

        RegistrarCreacion(creadoPor);
    }

    public void ModificarRecibo(DateTime ingreso, Area area, Vehiculo vehiculo, Tarifa tarifa, EstadoRecibo estadoRecibo, string modificadoPor)
    {
        Ingreso = ingreso;
        Area = area ?? throw new ArgumentNullException(nameof(area), "El área del recibo no puede estar vacío.");
        Vehiculo = vehiculo ?? throw new ArgumentNullException(nameof(vehiculo), "El vehículo del recibo no puede estar vacío.");
        Tarifa = tarifa ?? throw new ArgumentNullException(nameof(tarifa), "La tarifa del recibo no puede estar vacía.");
        EstadoRecibo = estadoRecibo;

        RegistrarModificacion(modificadoPor);
    }

    public ComprobantePago RetirarVehiculo(DateTime salida, MetodoComprobanteDePago metodoComprobanteDePago, decimal valorRecibido, Persona persona, string modificadoPor)
    {
        if (EstadoRecibo == EstadoRecibo.Cerrado)
        {
            throw new InvalidOperationException("El recibo ya fué cerrado.");
        }

        Salida = salida = Ingreso < salida
            ? salida
            : throw new ArgumentException("La fecha de salida es menor que la de ingreso.");
        Total = Tarifa.CalcularTarifa(Ingreso, salida);
        EstadoRecibo = EstadoRecibo.Cerrado;

        ComprobantePago comprobantePago =
            new ComprobantePago(this, metodoComprobanteDePago, Total, valorRecibido, persona);

        RegistrarModificacion(modificadoPor);

        return comprobantePago;
    }
}
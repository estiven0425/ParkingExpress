using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Tarifa : Base
{
    public string Nombre { get; private set; }
    public decimal Valor { get; private set; }
    public FrecuenciaTarifa Frecuencia { get; private set; }
    public TipoVehiculo TipoVehiculo { get; private set; }

    public ICollection<Recibo> Recibos { get; set; } =  new List<Recibo>();

    private Tarifa()
    {}

    public Tarifa(string nombre, decimal valor, FrecuenciaTarifa frecuencia, TipoVehiculo tipoVehiculo, string creadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre de la tarifa no puede estar vacío.")
            : nombre;
        Valor = valor < 0m
            ? throw new ArgumentOutOfRangeException(nameof(valor), valor, "El valor de la tarifa no puede ser negativo.")
            : valor;
        Frecuencia = frecuencia;
        TipoVehiculo = tipoVehiculo;

        RegistrarCreacion(creadoPor);
    }

    public void ModificarTarifa(string nombre, decimal valor, FrecuenciaTarifa frecuencia, TipoVehiculo tipoVehiculo, string modificadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre de la tarifa no puede estar vacío.")
            : nombre;
        Valor = valor < 0m
            ? throw new ArgumentOutOfRangeException(nameof(valor), valor, "El valor de la tarifa no puede ser negativo.")
            : valor;
        Frecuencia = frecuencia;
        TipoVehiculo = tipoVehiculo;

        RegistrarModificacion(modificadoPor);
    }

    public decimal CalcularTarifa(DateTime ingreso, DateTime salida)
    {
        if (ingreso >= salida)
        {
            throw new ArgumentException("La fecha de salida es menor a la de ingreso.");
        }

        TimeSpan diferencia = salida - ingreso;

        switch (Frecuencia)
        {
            case FrecuenciaTarifa.Dia:
                return Math.Ceiling((decimal)diferencia.TotalDays) * Valor;
            case FrecuenciaTarifa.Hora:
                return Math.Ceiling((decimal)diferencia.TotalHours) * Valor;
            default:
                throw new InvalidOperationException("No se encuentra una frecuencia válida.");
        }
    }
}
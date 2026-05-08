using System.ComponentModel.DataAnnotations;
using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public record Vehiculo{
    public int Id {get; init;}

    [MaxLength(255)]
    public string Placa { get; init; } = string.Empty;
    public TipoVehiculo TipoVehiculo { get; init; }

    private Vehiculo()
    {}

    public Vehiculo(string placa, TipoVehiculo tipoVehiculo)
    {
        Placa = placa;
        TipoVehiculo = tipoVehiculo;
    }
}
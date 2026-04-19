using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public record Vehiculo{
    public int Id {get; init;}
    public string Placa {get; init;}
    public TipoVehiculo TipoVehiculo { get; init; }

    public Vehiculo(string placa, TipoVehiculo tipoVehiculo)
    {
        Placa = placa;
        TipoVehiculo = tipoVehiculo;
    }
};
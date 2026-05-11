using ParkingExpress.Models;
using ParkingExpress.Models.Enums;

namespace ParkingExpress.Services;

public static class ReciboService
{
    public static Recibo IniciarEstadia(DateTime ingreso, Area area, Vehiculo vehiculo, Tarifa tarifa, string creadoPor)
    {
        if (area.ConsultarDisponibilidad() > 0)
        {
            Recibo recibo = new Recibo(ingreso, area, vehiculo, tarifa, creadoPor);

            area.OcuparArea();

            return recibo;
        }

        throw new InvalidOperationException("El recibo no pudo ser creado.");
    }

    public static ComprobantePago FinalizarEstadia(Recibo recibo, DateTime salida, MetodoComprobanteDePago metodoComprobanteDePago,
        decimal valorRecibido, Persona persona, string modificadoPor)
    {
        ComprobantePago comprobantePago = recibo.RetirarVehiculo(salida, metodoComprobanteDePago, valorRecibido, persona, modificadoPor);
        recibo.Area.LiberarArea();

        return comprobantePago;
    }
}
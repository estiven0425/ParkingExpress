using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class ComprobantePago : Base
{
    public int ReciboId { get; private set; }
    public Recibo Recibo { get; private set; }

    public DateTime Fecha  { get; private set; }
    public MetodoComprobanteDePago MetodoComprobanteDePago { get; private set; }

    public decimal ValorCobrado { get; private set; }
    public decimal ValorRecibido { get; private set; }
    public decimal ValorDevuelto { get; private set; }

    public EstadoComprobanteDePago EstadoComprobante { get; private set; }

    public int PersonaId { get; private set; }
    public Persona Persona { get; private set; }

    private  ComprobantePago()
    {}

    public ComprobantePago(Recibo recibo, MetodoComprobanteDePago metodoComprobanteDePago, decimal valorCobrado, decimal valorRecibido, Persona persona)
    {
        Recibo = recibo ??  throw new ArgumentNullException(nameof(recibo), "El recibo del comprobante de pago no puede estar vacío.");
        Fecha = DateTime.Now;
        MetodoComprobanteDePago = metodoComprobanteDePago;
        ValorCobrado = valorCobrado < 0
            ? throw new ArgumentOutOfRangeException(nameof(valorCobrado), valorCobrado, "El valor cobrado no puede ser menor a 0.")
            : valorCobrado;
        ValorRecibido = valorRecibido < 0
            ? throw new ArgumentOutOfRangeException(nameof(valorRecibido), valorRecibido, "El valor recibido no puede ser menor a 0.")
            : valorRecibido;
        ValorDevuelto = valorRecibido - valorCobrado >= 0
            ? valorRecibido - valorCobrado
            : 0m;
        EstadoComprobante = EstadoComprobanteDePago.Aprobado;
        Persona = persona ??  throw new ArgumentNullException(nameof(persona), "La persona que realizó el comprobante de pago no puede estar vacía.");
    }
}
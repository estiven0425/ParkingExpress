using ParkingExpress.Models.Enums;

namespace ParkingExpress.Models;

public class Area : Base
{
    public string Nombre { get; private set; }

    public int Capacidad { get; private set; }
    private int EnUso { get; set; }

    public TipoVehiculo TipoVehiculo { get; private set; }

    private Area()
    {}

    public Area(string nombre, int capacidad, TipoVehiculo tipoVehiculo, string creadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre del área no puede estar vacío.")
            : nombre;
        Capacidad = capacidad <= 0
            ? throw new ArgumentOutOfRangeException(nameof(capacidad), capacidad, "La capacidad del área no puede ser negativa o 0.")
            : capacidad;
        EnUso = 0;
        TipoVehiculo = tipoVehiculo;

        RegistrarCreacion(creadoPor);
    }

    public void ModificarArea(string nombre, int capacidad, TipoVehiculo tipoVehiculo, string modificadoPor)
    {
        Nombre = string.IsNullOrEmpty(nombre)
            ? throw new ArgumentNullException(nameof(nombre), "El nombre del área no puede estar vacío.")
            : nombre;
        Capacidad = capacidad < EnUso
            ? throw new ArgumentOutOfRangeException(nameof(capacidad), capacidad, "La capacidad del área no puede ser menor a los espacios ocupados.")
            : capacidad;
        TipoVehiculo = tipoVehiculo;

        RegistrarModificacion(modificadoPor);
    }

    public void OcuparArea()
    {
        if (EnUso < Capacidad)
        {
            EnUso++;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(EnUso), EnUso,
                "No es posible ocupar un espacio en esta área, está llena");
        }
    }

    public void LiberarArea()
    {
        if (EnUso > 0)
        {
            EnUso--;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(EnUso), EnUso,
                "No es posible liberar un espacio en esta área, está vacía");
        }
    }

    public int ConsultarDisponibilidad()
    {
        return Capacidad - EnUso;
    }
}
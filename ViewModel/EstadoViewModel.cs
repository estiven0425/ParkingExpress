using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ParkingExpress.Commands;
using ParkingExpress.Services;

namespace ParkingExpress.ViewModel;

public class EstadoViewModel : BaseViewModel
{
    private DateTime _tiempo;
    public DateTime Tiempo
    {
        get => _tiempo;
        set => SetField(ref _tiempo, value);
    }

    private readonly DispatcherTimer _timer;

    private string _usuario = string.Empty;
    public string Usuario
    {
        get => _usuario;
        set => SetField(ref _usuario, value);
    }

    public ICommand CerrarSesionCommand { get; set; }

    public EstadoViewModel()
    {
        Tiempo = DateTime.Now;
        Usuario = string.IsNullOrEmpty(SesionService.UsuarioActual?.NombreUsuario)
            ? string.Empty
            : SesionService.UsuarioActual.NombreUsuario;

        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += ActualizarHora;
        _timer.Start();

        CerrarSesionCommand = new RelayCommand(CerrarSesion, PuedeCerrarSesion);
    }

    private void ActualizarHora(object? sender, EventArgs e)
    {
        try
        {
            Tiempo = DateTime.Now;
        }
        catch (Exception exception)
        {
            MessageBox.Show("Ha ocurrido un error al actualizar la hora.", "Error al actualizar hora.", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CerrarSesion(Object? parameter)
    {
        try
        {
            Error = string.Empty;

            SesionService.CerrarSesion();
            NavegacionService.NavegacionLogin();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error de sesión.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

    }

    private bool PuedeCerrarSesion(Object? parameter)
    {
        if (SesionService.UsuarioActual != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
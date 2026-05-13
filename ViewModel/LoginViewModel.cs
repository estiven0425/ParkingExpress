using System.Windows;
using System.Windows.Input;
using ParkingExpress.Commands;
using ParkingExpress.Services;

namespace ParkingExpress.ViewModel;

public class LoginViewModel : BaseViewModel
{
    private string _nombreUsuario =  string.Empty;
    public string NombreUsuario
    {
        get => _nombreUsuario;
        set => SetField(ref _nombreUsuario, value);
    }

    private string _contrasena = string.Empty;
    public string Contrasena
    {
        get => _contrasena;
        set => SetField(ref _contrasena, value);
    }

    public ICommand IniciarSesionCommand { get; set; }

    public LoginViewModel()
    {
        IniciarSesionCommand = new RelayCommand(IniciarSesion, PuedeIniciarSesion);
    }

    private void IniciarSesion(object? parameter)
    {
        Error = string.Empty;

        try
        {
            SesionService.IniciarSesion(NombreUsuario, Contrasena);

            NavegacionService.NavegacionMain();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error de credenciales.", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }

    private bool PuedeIniciarSesion(object? parameter)
    {
        if (string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(Contrasena))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
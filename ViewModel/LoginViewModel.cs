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

    private string _error = string.Empty;
    public string Error
    {
        get => _error;
        set => SetField(ref _error, value);
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
        catch (Exception e)
        {
            Error = e.Message;
        }
    }

    private bool PuedeIniciarSesion(object? parameter)
    {
        if (string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(Contrasena))
        {
            return false;
        }

        return true;
    }
}
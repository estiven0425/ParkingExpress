using System.Windows;
using System.Windows.Controls;
using ParkingExpress.ViewModel;
using ParkingExpress.Views;

namespace ParkingExpress.Services;

public static class NavegacionService
{
    public static MainViewModel MainViewModel = null!;

    public static void NavegacionInterna(UserControl userControl)
    {
        MainViewModel.Navegacion(userControl);
    }

    public static void NavegacionMain()
    {
        if (SesionService.UsuarioActual != null)
        {
            MainWindow mainWindow = new MainWindow();

            Application.Current.MainWindow = mainWindow;

            mainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginWindow)
                {
                    window.Close();
                    break;
                }
            }
        }
        else
        {
            throw new UnauthorizedAccessException("El usuario no existe en la sesión.");
        }
    }

    public static void NavegacionLogin()
    {
        if (SesionService.UsuarioActual is null)
        {
            LoginWindow loginWindow = new LoginWindow();

            Application.Current.MainWindow = loginWindow;

            loginWindow.Show();

            foreach (Window window in Application.Current.Windows.Cast<Window>().ToList())
            {
                if (window is not LoginWindow)
                {
                    window.Close();
                }
            }
        }
        else
        {
            throw new UnauthorizedAccessException("El usuario existe en la sesión.");
        }
    }
    public static void NavegacionReciboDetalleDashboard()
    {
        if (SesionService.UsuarioActual != null)
        {
            DetalleReciboDashboardWindow reciboMainWindow = new DetalleReciboDashboardWindow();

            reciboMainWindow.Show();
        }
        else
        {
            throw new UnauthorizedAccessException("El usuario no existe en la sesión.");
        }
    }
}
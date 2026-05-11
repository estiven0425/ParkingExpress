using System.Windows;
using ParkingExpress.Views;

namespace ParkingExpress.Services;

public static class NavegacionService
{
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
}
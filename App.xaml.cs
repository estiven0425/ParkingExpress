using System.Windows;
using ParkingExpress.Data;
using ParkingExpress.Services;
using ParkingExpress.Views;

namespace ParkingExpress;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        using AppDbContext appDbContext = new AppDbContext();

        DbInitializer.Initializer(appDbContext);

        LoginWindow loginWindow = new LoginWindow();
        MainWindow mainWindow = new MainWindow();


        if (SesionService.UsuarioActual == null)
        {
            loginWindow.Show();
        }
        else
        {
            mainWindow.Show();
        }

        base.OnStartup(e);
    }
}
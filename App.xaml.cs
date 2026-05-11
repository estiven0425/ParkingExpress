using System.Windows;
using ParkingExpress.Data;
using ParkingExpress.Views;

namespace ParkingExpress;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        using AppDbContext appDbContext = new AppDbContext();

        DbInitializer.Initializer(appDbContext);

        LoginWindow loginWindow = new LoginWindow();

        loginWindow.Show();

        base.OnStartup(e);
    }
}
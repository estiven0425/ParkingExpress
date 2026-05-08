using System.Windows;
using ParkingExpress.Data;

namespace ParkingExpress;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        using AppDbContext appDbContext = new AppDbContext();

        DbInitializer.Initializer(appDbContext);

        base.OnStartup(e);
    }
}
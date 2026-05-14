using System.Windows;
using System.Windows.Controls;
using ParkingExpress.Controls;

namespace ParkingExpress.ViewModel;

public class MainViewModel : BaseViewModel
{
    private UserControl _vistaActual = null!;
    public UserControl VistaActual
    {
        get => _vistaActual;
        set => SetField(ref _vistaActual, value);
    }

    public MainViewModel()
    {
        VistaActual = new Dashboard();
    }
    public void Navegacion(UserControl userControl)
    {
        if (userControl.GetType() != VistaActual.GetType())
        {
            if (VistaActual.DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }

            VistaActual = userControl;
        }
        else
        {
            MessageBox.Show("No se puede renderizar la vista solicitada.", "Error de navegación.", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
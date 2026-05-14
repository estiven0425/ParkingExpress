using System.Windows;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Views;

public partial class DetalleReciboDashboardWindow : Window
{
    public DetalleReciboDashboardWindow()
    {
        InitializeComponent();

        DataContext = new DetalleReciboDashboardViewModel();
    }
}
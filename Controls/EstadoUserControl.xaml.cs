using System.Windows.Controls;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Controls;

public partial class EstadoUserControl : UserControl
{
    public EstadoUserControl()
    {
        InitializeComponent();

        DataContext = new EstadoViewModel();
    }
}
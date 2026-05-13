using System.Windows.Controls;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Controls;

public partial class MenuUserControl : UserControl
{
    public MenuUserControl()
    {
        InitializeComponent();

        DataContext = new MenuViewModel();
    }
}
using System.Windows;
using System.Windows.Controls;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Controls;

public partial class Dashboard : UserControl
{
    public Dashboard()
    {
        InitializeComponent();

        DataContext = new DashboardViewModel();
    }
}
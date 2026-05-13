using System.Windows;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}
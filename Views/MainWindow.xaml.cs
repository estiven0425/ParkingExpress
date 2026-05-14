using System.Windows;
using ParkingExpress.Services;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MainViewModel mainViewModel = new MainViewModel();

        DataContext = mainViewModel;

        NavegacionService.MainViewModel = mainViewModel;
    }
}
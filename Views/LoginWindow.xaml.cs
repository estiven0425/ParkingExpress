using System.Windows;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();

        DataContext = new LoginViewModel();
    }
}
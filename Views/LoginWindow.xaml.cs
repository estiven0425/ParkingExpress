using System.Windows;
using System.Windows.Controls;
using ParkingExpress.ViewModel;

namespace ParkingExpress.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();

        DataContext = new LoginViewModel();
    }

    private void IngresarContrasena(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;

        LoginViewModel loginViewModel = (LoginViewModel)DataContext;

        loginViewModel.Contrasena = passwordBox.Password;
    }
}
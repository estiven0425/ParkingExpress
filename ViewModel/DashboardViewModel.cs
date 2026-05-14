using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ParkingExpress.Commands;
using ParkingExpress.Data;
using ParkingExpress.Models;
using ParkingExpress.Services;

namespace ParkingExpress.ViewModel;

public class DashboardViewModel : BaseViewModel, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public ICommand DetalleReciboCommand { get; set; }

    public ObservableCollection<Recibo> Recibos { get; set; }

    public DashboardViewModel()
    {
        _appDbContext = new AppDbContext();

        DetalleReciboCommand = new RelayCommand(DetalleRecibo, PuedeDetalleRecibo);

        Recibos = new ObservableCollection<Recibo>();

        CargarRecibos();
    }

    private void CargarRecibos()
    {
        List<Recibo> recibos = _appDbContext.Recibos.Include(recibo => recibo.Area).Include(recibo => recibo.Vehiculo)
            .OrderByDescending(recibo => recibo.Ingreso).ToList();

        foreach (Recibo recibo in recibos)
        {
            Recibos.Add(recibo);
        }
    }

    private void DetalleRecibo(object? parameter)
    {
        Error = string.Empty;

        try
        {
            NavegacionService.NavegacionReciboDetalleDashboard();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error al abrir la vista detallada del recibo.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

    }

    private bool PuedeDetalleRecibo(object? parameter)
    {
        if (parameter is Recibo recibo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
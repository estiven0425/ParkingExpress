using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParkingExpress.ViewModel;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    private string _error = string.Empty;
    public string Error
    {
        get => _error;
        set => SetField(ref _error, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;

        OnPropertyChanged(propertyName);

        return true;
    }
}
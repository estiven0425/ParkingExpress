namespace ParkingExpress.Helpers;

public static class Validaciones
{
    public static bool EsCero(int valor) => valor.Equals(0);
    public static bool EsMenorQueCero(int valor) => valor < 0;
    public static bool EsVacioONulo(string valor) => string.IsNullOrEmpty(valor);
}
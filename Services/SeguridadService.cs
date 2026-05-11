using System.Security.Cryptography;

namespace ParkingExpress.Services;

public static class SeguridadService
{
    public static string EncriptarContrasena(string contrasena)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password: contrasena,
            salt: salt,
            iterations: 100000,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: 32
        );
        
        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    public static bool VerificarContrasena(string contrasena, string contrasenaAlmacenada)
    {
        string[] partes = contrasenaAlmacenada.Split(":");
        
        byte[] salt = Convert.FromBase64String(partes[0]);
        
        byte[] hashAlmacenado = Convert.FromBase64String(partes[1]);
        
        byte[] hashNuevo = Rfc2898DeriveBytes.Pbkdf2(
            password: contrasena,
            salt: salt,
            iterations: 100000,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: 32
        );

        return CryptographicOperations.FixedTimeEquals(hashNuevo, hashAlmacenado);
    }

    public static string CambiarContrasena(string contrasenaNueva, string contrasenaActual, string contrasenaAlmacenada)
    {
        bool autenticacion =  VerificarContrasena(contrasenaActual, contrasenaAlmacenada);

        return autenticacion
            ? EncriptarContrasena(contrasenaNueva)
            : throw new UnauthorizedAccessException("Credenciales inválidas.");
    }
}
using System.IO;
using Microsoft.EntityFrameworkCore;
using ParkingExpress.Models;

namespace ParkingExpress.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Tarifa> Tarifas { get; set; }
    public DbSet<Recibo> Recibos { get; set; }
    public DbSet<ComprobantePago> ComprobantePagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databasePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Database",
            "ParkingExpress.db"
        );

        Directory.CreateDirectory(
            Path.GetDirectoryName(databasePath)!
        );

        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasOne(usuario => usuario.Persona).WithOne().HasForeignKey<Usuario>(usuario => usuario.PersonaId);
        modelBuilder.Entity<ComprobantePago>().HasOne(comprobantePago => comprobantePago.Recibo).WithOne().HasForeignKey<ComprobantePago>(comprobantePago => comprobantePago.ReciboId);

        modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.NombreUsuario).IsUnique();
        modelBuilder.Entity<Rol>().HasIndex(rol => rol.Nombre).IsUnique();
        modelBuilder.Entity<Persona>().HasIndex(persona => persona.Identificacion).IsUnique();
        modelBuilder.Entity<Area>().HasIndex(area => area.Nombre).IsUnique();
        modelBuilder.Entity<Tarifa>().HasIndex(tarifa => tarifa.Nombre).IsUnique();
        modelBuilder.Entity<ComprobantePago>().HasIndex(comprobantePago => comprobantePago.ReciboId).IsUnique();
    }
}
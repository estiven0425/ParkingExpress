using Microsoft.EntityFrameworkCore;

namespace ParkingExpress.Data;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ./Database/ParkingExpress.db");
    }
}
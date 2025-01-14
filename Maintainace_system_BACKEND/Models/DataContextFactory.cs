using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Maintainace_system_BACKEND.Models
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Konfigurācijas ielāde
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Savienojuma virknes iegūšana
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContext opciju izveide
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 4, 3)) // Jūsu MySQL servera versija
            );

            return new DataContext(optionsBuilder.Options);
        }
    }
}
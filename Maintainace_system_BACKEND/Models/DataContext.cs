using Maintainace_system_BACKEND.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Maintainace_system_BACKEND.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeIdent> EmployeeIdents { get; set; }
        public DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeIdentConfiguration());
            modelBuilder.ApplyConfiguration(new FilesConfiguration()); // Apply Files configuration

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:mariuss.database.windows.net,1433;Initial Catalog=BBIT_MKG;Persist Security Info=False;User ID=admin_mkg;Password=HyperX3146!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", options =>
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                )
            );
        }

    }
}
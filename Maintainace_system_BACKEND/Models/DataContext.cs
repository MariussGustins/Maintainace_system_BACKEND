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
        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeIdentConfiguration());
            modelBuilder.ApplyConfiguration(new FilesConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=genteelly-economic-finch.data-1.use1.tembo.io;Port=5432;User Id=postgres;Password=lSqGe6iwBomJ2nti;Database=postgres;SslMode=VerifyFull;TrustServerCertificate=true", options =>
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                )
            );
        }

    }
}
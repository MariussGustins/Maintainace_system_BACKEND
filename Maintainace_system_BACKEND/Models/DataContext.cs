using Maintainace_system_BACKEND.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Maintainace_system_BACKEND.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /** DbSet objekti, kas atbilst datu bāzes tabulām */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeIdent> EmployeeIdents { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }

        /**
         * Konfigurē datu bāzes tabulu nosaukumus un attiecības starp entītijām.
         * @param modelBuilder - Entity Framework modelis.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees"); // Atbilst tabulas nosaukumam
            modelBuilder.Entity<EmployeeIdent>().ToTable("EmployeeIdents"); // Atbilst tabulai
            modelBuilder.Entity<EmployeeRoles>().ToTable("EmployeeRoles"); // Atbilst tabulai
            modelBuilder.Entity<Files>().ToTable("Files");
            modelBuilder.Entity<Projects>().ToTable("Projects");
            
            // Pielieto konfigurācijas atbilstošām entītijām
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeIdentConfiguration());
            modelBuilder.ApplyConfiguration(new FilesConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRolesConfiguration());

            // Attiecības starp EmployeeIdent un Employee
            modelBuilder.Entity<EmployeeIdent>()
                .HasOne(ei => ei.Employee)
                .WithMany(e => e.EmployeeIdents)
                .HasForeignKey(ei => ei.EmployeeId); // Norādiet precīzu ārējās atslēgas lauku

            // Attiecības starp Employee un EmployeeRoles
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.Role_Id); 
        }

        /**
         * Konfigurē datu bāzes pieslēgumu un atkārtotu pievienošanos kļūdu gadījumā.
         * @param optionsBuilder - Datubāzes pieslēguma opcijas.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=database-1.cd0m46mqkm83.eu-north-1.rds.amazonaws.com;Port=3306;User Id=admin;Password=HyperX3146!;Database=MKG;",
                new MySqlServerVersion(new Version(8, 4, 3)), 
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                )
            );
        }
    }
}

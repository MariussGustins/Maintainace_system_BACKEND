using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    /**
     * Konfigurē Employee entītijas struktūru un īpašības.
     * @param builder - EntityTypeBuilder instance priekš Employee entītijas konfigurācijas.
     */
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees"); // Norāda tabulas nosaukumu datu bāzē
        builder.HasKey(e => e.Id); // Primārās atslēgas definēšana
        builder.Property(e => e.Id).ValueGeneratedOnAdd(); // Automātiska ID ģenerēšana
        builder.Property(e => e.Name).IsRequired(); // Nosaukuma lauks ir obligāts
        builder.Property(e => e.Surname).IsRequired(); // Uzvārda lauks ir obligāts
        builder.Property(e => e.Role_Id).IsRequired(); // Lomas ID ir obligāts
        builder.Property(e => e.PictureUrl).IsRequired(); // Profila attēla URL ir obligāts
    }
}

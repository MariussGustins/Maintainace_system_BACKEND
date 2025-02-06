using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class EmployeeIdentConfiguration : IEntityTypeConfiguration<EmployeeIdent>
{
    /**
     * Konfigurē EmployeeIdent entītijas struktūru un īpašības.
     * @param builder - EntityTypeBuilder instance priekš EmployeeIdent entītijas konfigurācijas.
     */
    public void Configure(EntityTypeBuilder<EmployeeIdent> builder)
    {
        builder.ToTable("EmployeeIdents"); // Norāda tabulas nosaukumu datu bāzē
        builder.HasKey(ei => ei.Id); // Primārās atslēgas definēšana
        builder.Property(ei => ei.Id).ValueGeneratedOnAdd(); // Automātiska ID ģenerēšana
        builder.Property(ei => ei.Username).IsRequired(); // Lietotājvārda lauks ir obligāts
        builder.Property(ei => ei.Password).IsRequired(); // Paroles lauks ir obligāts
        
        // Attiecību definēšana starp EmployeeIdent un Employee tabulu
        builder.HasOne(ei => ei.Employee)
            .WithOne()
            .HasForeignKey<EmployeeIdent>(ei => ei.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade); // Nodrošina, ka darbinieka identifikators tiek dzēsts kopā ar darbinieku
    }
}

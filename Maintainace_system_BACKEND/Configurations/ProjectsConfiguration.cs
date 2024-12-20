using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class ProjectsConfiguration : IEntityTypeConfiguration<Projects>
{
    public void Configure(EntityTypeBuilder<Projects> builder)
    {
        // Tabulas nosaukums
        builder.ToTable("Projects");

        // Primārā atslēga
        builder.HasKey(p => p.Id);

        // Kolonnu konfigurācija
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Automātiska ID ģenerācija

        builder.Property(p => p.ProjectName)
            .IsRequired() // Obligāts lauks
            .HasMaxLength(200); // Maksimālais garums

        builder.Property(p => p.Description)
            .HasMaxLength(500); // Maksimālais garums

        builder.Property(p => p.StartDate)
            .IsRequired() // Obligāts lauks
            .HasMaxLength(20);

        builder.Property(p => p.EndDate)
            .HasMaxLength(20);

        builder.Property(p => p.IsActive)
            .IsRequired(); // Obligāts lauks

        // Papildu konfigurācijas var pievienot šeit
    }
}
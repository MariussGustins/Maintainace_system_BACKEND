using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

// Konfigurācijas klase darbinieku lomu tabulai
public class EmployeeRolesConfiguration : IEntityTypeConfiguration<EmployeeRoles>
{
    public void Configure(EntityTypeBuilder<EmployeeRoles> builder)
    {
        // Tabulas nosaukums
        builder.ToTable("EmployeeRoles");

        // Primārās atslēgas konfigurācija
        builder.HasKey(er => er.Id);

        // Kolonnu konfigurācija
        builder.Property(er => er.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); // Automātiski ģenerēta ID vērtība

        builder.Property(er => er.RoleName)
            .IsRequired()
            .HasMaxLength(100); // Maksimālais garums - 100 rakstzīmes

        // Papildu indeksi vai attiecības, ja nepieciešams
    }
}
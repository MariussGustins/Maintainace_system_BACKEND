using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class FilesConfiguration : IEntityTypeConfiguration<Files>
{
    public void Configure(EntityTypeBuilder<Files> builder)
    {
        // Defineta tasbula
        builder.ToTable("Files");

        // Defineta primārā atslēga
        builder.HasKey(f => f.Id);

        // Definēti nosacījumi un relācijas
        builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(f => f.FilePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(f => f.FileSize)
            .IsRequired();

        builder.Property(f => f.FileType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Date)
            .IsRequired();

        builder.Property(f => f.Description)
            .HasMaxLength(1000);

        builder.Property(f => f.IsActive)
            .IsRequired();

        builder.Property(f => f.EmployeeIdentId)
            .IsRequired();

        
        builder.HasOne<EmployeeIdent>()
            .WithMany() 
            .HasForeignKey(f => f.EmployeeIdentId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
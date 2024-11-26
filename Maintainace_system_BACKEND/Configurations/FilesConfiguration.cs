using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class FilesConfiguration : IEntityTypeConfiguration<Files>
{
    public void Configure(EntityTypeBuilder<Files> builder)
    {
        // Define the table name
        builder.ToTable("Files");

        // Define the primary key
        builder.HasKey(f => f.Id);

        // Define properties
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

        // Define relationships if necessary
        // Example: If Files has a foreign key relationship with EmployeeIdent
        builder.HasOne<EmployeeIdent>()
            .WithMany() // Adjust this if EmployeeIdent has a collection of Files
            .HasForeignKey(f => f.EmployeeIdentId)
            .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
    }
}
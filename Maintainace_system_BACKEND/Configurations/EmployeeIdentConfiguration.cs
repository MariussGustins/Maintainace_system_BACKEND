using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maintainace_system_BACKEND.Configurations;

public class EmployeeIdentConfiguration : IEntityTypeConfiguration<EmployeeIdent>
{
    public void Configure(EntityTypeBuilder<EmployeeIdent> builder)
    {
        builder.ToTable("EmployeeIdents");
        builder.HasKey(ei => ei.Id);
        builder.Property(ei => ei.Id).ValueGeneratedOnAdd();
        builder.Property(ei => ei.Username).IsRequired();
        builder.Property(ei => ei.Password).IsRequired();
        builder.HasOne(ei => ei.Employee)
            .WithOne()
            .HasForeignKey<EmployeeIdent>(ei => ei.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
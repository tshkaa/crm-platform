using DirectoryService.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("departments_locations");
        
        builder.HasKey(dl => dl.Id).HasName("pk_departments_locations");

        builder.Property(dl => dl.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        builder.Property(dl => dl.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dl => dl.LocationId)
            .HasColumnName("location_id")
            .IsRequired();
        
        builder.Property(dl => dl.IsPrimary)
            .HasColumnName("is_primary")
            .IsRequired();
    }
}
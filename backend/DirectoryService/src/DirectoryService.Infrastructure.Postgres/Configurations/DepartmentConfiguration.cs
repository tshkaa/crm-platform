using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");
        
        builder.HasKey(d => d.Id).HasName("pk_departments");
        
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        builder.Property(d => d.Name)
            .HasConversion(n => n.Value, v => new Title(v))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(d => d.Slug)
            .HasConversion(s => s.Value, v => new DepartmentSlug(v))
            .HasColumnName("slug")
            .HasMaxLength(DepartmentSlug.MaxLength)
            .IsRequired();
        
        builder.Property(d => d.Path)
            .HasConversion(s => s.Value, v => new DepartmentPath(v))
            .HasColumnName("path")
            .HasMaxLength(LengthConstants.Length500)
            .IsRequired();
    }
}
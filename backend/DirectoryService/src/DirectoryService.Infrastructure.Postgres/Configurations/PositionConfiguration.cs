using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");
        
        builder.HasKey(p => p.Id).HasName("pk_positions");

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        builder.Property(l => l.Name)
            .HasConversion(n => n.Value, v => new Title(v))
            .HasColumnName("name")
            .HasMaxLength(LengthConstants.Length100)
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .HasColumnName("updated_at")
            .IsRequired();
        
        builder.HasMany<DepartmentPosition>()
            .WithOne()
            .HasForeignKey(d => d.PositionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(l => l.Id).HasName("pk_locations");
        
        builder.Property(l => l.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        builder.Property(l => l.Name)
            .HasConversion(n => n.Value, v => new Title(v))
            .HasColumnName("name")
            .HasMaxLength(LengthConstants.Length100)
            .IsRequired();

        builder.OwnsOne(l => l.Address, lb =>
        {
            lb.ToJson("address");

            lb.Property(a => a.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(LengthConstants.Length100);
            lb.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(LengthConstants.Length100);
            lb.Property(a => a.Building)
                .HasColumnName("building")
                .IsRequired()
                .HasMaxLength(LengthConstants.Length100);
            lb.Property(a => a.Apartment)
                .HasColumnName("apartment")
                .IsRequired()
                .HasMaxLength(LengthConstants.Length100);
        });
        
        builder.Property(l => l.CreatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(l => l.UpdatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .HasColumnName("updated_at")
            .IsRequired();
        
        builder.HasMany<DepartmentLocation>()
            .WithOne()
            .HasForeignKey(d => d.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
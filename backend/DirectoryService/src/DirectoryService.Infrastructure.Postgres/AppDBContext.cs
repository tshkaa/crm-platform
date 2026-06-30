using Microsoft.EntityFrameworkCore;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Positions;
namespace DirectoryService.Infrastructure.Postgres;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Position> Positions { get; set; }
}
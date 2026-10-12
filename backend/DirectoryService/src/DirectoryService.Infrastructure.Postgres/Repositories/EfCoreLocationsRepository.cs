using DirectoryService.Core.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public class EfCoreLocationsRepository : ILocationsRepository
{
    private readonly AppDbContext _dbContext;

    public EfCoreLocationsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Guid> AddAsync(Location location, CancellationToken cancellationToken)
    {
        await _dbContext.Locations.AddAsync(location, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return location.Id;
    }

    public async Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken)
    {
        var title = new Title(name);

        return !await _dbContext.Locations.AnyAsync(
            l => l.Name == title, cancellationToken);
    }
}
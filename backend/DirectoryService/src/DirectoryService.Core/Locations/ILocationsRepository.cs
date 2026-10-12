using DirectoryService.Domain.Locations;

namespace DirectoryService.Core.Locations;

public interface ILocationsRepository
{
    Task<Guid> AddAsync(Location location, CancellationToken cancellationToken);
    
    Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken);
}
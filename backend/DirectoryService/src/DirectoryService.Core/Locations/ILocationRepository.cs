using DirectoryService.Domain.Locations;

namespace DirectoryService.Core.Locations;

public interface ILocationRepository
{
    Task<Guid> AddAsync(Location location, CancellationToken cancellationToken);
    
    Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken);
}
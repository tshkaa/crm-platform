using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Locations;

public sealed class Location
{
    public Location(Title name, LocationAddress address)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public Guid Id { get; private set; }
    
    public Title Name { get; private set; }
    
    public LocationAddress Address { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}
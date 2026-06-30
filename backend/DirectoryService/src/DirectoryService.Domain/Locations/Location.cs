using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Locations;

public sealed class Location
{
    // Для EF Core
    private Location()
    {
    }
    
    public Location(Title name, LocationAddress address)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; }

    public Title Name { get; private set; } = null!;

    public LocationAddress Address { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
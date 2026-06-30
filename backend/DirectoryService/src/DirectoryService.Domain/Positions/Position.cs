using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Positions;

public sealed class Position
{
    // Для EF Core
    private Position()
    {
    }
    
    public Position(Title name)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; }

    public Title Name { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
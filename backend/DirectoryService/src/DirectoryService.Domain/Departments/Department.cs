using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    public Department(
        Title name,
        Guid? parentId = null)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        ParentId = parentId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public Guid Id { get; private set; }

    public Title Name { get; private set; }

    public Guid? ParentId { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}
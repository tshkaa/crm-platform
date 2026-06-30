using System.Runtime.InteropServices;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    // Для EF Core
    private Department()
    {
    }
    
    public Department(
        Title name,
        DepartmentSlug slug,
        DepartmentPath path,
        Guid? parentId = null)
    {
        if (parentId == null)
        {
            // Корневой отдел должен иметь путь, совпадающий с его slag
            if (path != null && !string.Equals(path.Value, slug.Value, StringComparison.Ordinal))
            {
                throw new ArgumentException(
                    $"For root department, path '{path.Value}' must equal slug '{slug.Value}'.",
                    nameof(path));
            }

            path ??= new DepartmentPath(slug.Value);
        }
        else
        {
            if (path == null)
                throw new ArgumentException("Non-root department must have a path ending with its slug.", nameof(path));
            if(!path.Value.EndsWith($"/{slug.Value}", StringComparison.Ordinal))
                throw new ArgumentException("Department path must end with the slug.", nameof(path));
        }

        Id = Guid.CreateVersion7();
        Name = name;
        Slug = slug;
        Path = path;
        ParentId = parentId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; }

    public Title Name { get; private set; } = null!;

    public DepartmentSlug Slug { get; private set; } = null!;

    public DepartmentPath Path { get; private set; } = null!;

    public Guid? ParentId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
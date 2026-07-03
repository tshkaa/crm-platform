namespace DirectoryService.Contracts;

public record CreateDepartmentRequest(string Name, string Slug, string Path, string? ParentId = null);
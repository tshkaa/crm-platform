namespace DirectoryService.Contracts;

public record UpdateDepartmentRequest(string Name, string Slug, string Path, string? ParentId = null);
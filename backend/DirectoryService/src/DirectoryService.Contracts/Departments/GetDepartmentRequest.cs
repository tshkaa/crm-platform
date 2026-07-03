namespace DirectoryService.Contracts;

public record GetDepartmentRequest(string? Search, int Page = 1, int PageSize = 10);
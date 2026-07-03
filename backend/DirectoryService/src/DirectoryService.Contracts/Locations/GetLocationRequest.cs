namespace DirectoryService.Contracts.Locations;

public record GetLocationRequest(string? Search, int Page = 1, int PageSize = 10);
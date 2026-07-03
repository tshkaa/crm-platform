namespace DirectoryService.Contracts.Positions;

public record GetPositionRequest(string? Search, int Page = 1, int PageSize = 10);
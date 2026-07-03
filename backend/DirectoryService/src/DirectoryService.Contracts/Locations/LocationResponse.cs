namespace DirectoryService.Contracts.Locations;

public record LocationResponse(
    Guid Id,
    string Name,
    string Address,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
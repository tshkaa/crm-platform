namespace DirectoryService.Contracts.Locations;

public record LocationResponse(
    Guid Id,
    string Name,
    AdressDto Address,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
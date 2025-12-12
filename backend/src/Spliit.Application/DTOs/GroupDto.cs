namespace Spliit.Application.DTOs;

public record GroupDto(
    Guid Id,
    string Name,
    string? Information,
    string Currency,
    string? CurrencyCode,
    DateTime CreatedAt
);

public record CreateGroupDto(
    string Name,
    string? Information,
    string Currency,
    string? CurrencyCode
);

public record UpdateGroupDto(
    string Name,
    string? Information,
    string Currency,
    string? CurrencyCode
);

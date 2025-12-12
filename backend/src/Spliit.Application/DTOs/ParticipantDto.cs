namespace Spliit.Application.DTOs;

public record ParticipantDto(
    Guid Id,
    string Name,
    Guid GroupId,
    DateTime CreatedAt
);

public record CreateParticipantDto(
    string Name,
    Guid GroupId
);

public record UpdateParticipantDto(
    string Name
);

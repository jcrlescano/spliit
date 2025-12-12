using Spliit.Application.DTOs;

namespace Spliit.Application.Interfaces;

public interface IGroupService
{
    Task<GroupDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GroupDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<GroupDto> CreateAsync(CreateGroupDto dto, CancellationToken cancellationToken = default);
    Task<GroupDto?> UpdateAsync(Guid id, UpdateGroupDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

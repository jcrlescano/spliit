using Spliit.Application.DTOs;
using Spliit.Application.Interfaces;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;

namespace Spliit.Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
    {
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GroupDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.GetByIdAsync(id, cancellationToken);
        return group == null ? null : MapToDto(group);
    }

    public async Task<IEnumerable<GroupDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var groups = await _groupRepository.GetAllAsync(cancellationToken);
        return groups.Select(MapToDto);
    }

    public async Task<GroupDto> CreateAsync(CreateGroupDto dto, CancellationToken cancellationToken = default)
    {
        var group = new Group
        {
            Name = dto.Name,
            Information = dto.Information,
            Currency = dto.Currency,
            CurrencyCode = dto.CurrencyCode
        };

        await _groupRepository.AddAsync(group, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(group);
    }

    public async Task<GroupDto?> UpdateAsync(Guid id, UpdateGroupDto dto, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.GetByIdAsync(id, cancellationToken);
        if (group == null) return null;

        group.Name = dto.Name;
        group.Information = dto.Information;
        group.Currency = dto.Currency;
        group.CurrencyCode = dto.CurrencyCode;
        group.UpdatedAt = DateTime.UtcNow;

        _groupRepository.Update(group);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(group);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.GetByIdAsync(id, cancellationToken);
        if (group == null) return false;

        _groupRepository.Delete(group);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static GroupDto MapToDto(Group group) => new(
        group.Id,
        group.Name,
        group.Information,
        group.Currency,
        group.CurrencyCode,
        group.CreatedAt
    );
}

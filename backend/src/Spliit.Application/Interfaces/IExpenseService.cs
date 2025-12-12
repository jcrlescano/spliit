using Spliit.Application.DTOs;

namespace Spliit.Application.Interfaces;

public interface IExpenseService
{
    Task<ExpenseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ExpenseDto>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default);
    Task<ExpenseDto> CreateAsync(CreateExpenseDto dto, CancellationToken cancellationToken = default);
    Task<ExpenseDto?> UpdateAsync(Guid id, UpdateExpenseDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

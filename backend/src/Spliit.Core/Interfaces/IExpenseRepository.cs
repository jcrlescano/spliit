using Spliit.Core.Entities;

namespace Spliit.Core.Interfaces;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<IEnumerable<Expense>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default);
    Task<Expense?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
}

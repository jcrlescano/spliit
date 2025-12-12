using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;

namespace Spliit.Infrastructure.Repositories;

public class ExpenseRepository : Repository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Expense>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(e => e.GroupId == groupId).ToListAsync(cancellationToken);
    }

    public async Task<Expense?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(e => e.PaidBy)
            .Include(e => e.PaidFor)
            .Include(e => e.Documents)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}

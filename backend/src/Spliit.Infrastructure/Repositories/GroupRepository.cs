using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;

namespace Spliit.Infrastructure.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Group?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(g => g.Participants)
            .Include(g => g.Expenses)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;

namespace Spliit.Infrastructure.Repositories;

public class ActivityRepository : Repository<Activity>, IActivityRepository
{
    public ActivityRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Activity>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(a => a.GroupId == groupId).OrderByDescending(a => a.Time).ToListAsync(cancellationToken);
    }
}

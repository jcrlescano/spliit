using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;

namespace Spliit.Infrastructure.Repositories;

public class ParticipantRepository : Repository<Participant>, IParticipantRepository
{
    public ParticipantRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Participant>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(p => p.GroupId == groupId).ToListAsync(cancellationToken);
    }
}

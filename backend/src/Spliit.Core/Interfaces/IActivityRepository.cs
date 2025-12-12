using Spliit.Core.Entities;

namespace Spliit.Core.Interfaces;

public interface IActivityRepository : IRepository<Activity>
{
    Task<IEnumerable<Activity>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default);
}

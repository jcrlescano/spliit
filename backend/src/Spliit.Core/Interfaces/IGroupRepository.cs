using Spliit.Core.Entities;

namespace Spliit.Core.Interfaces;

public interface IGroupRepository : IRepository<Group>
{
    Task<Group?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
}

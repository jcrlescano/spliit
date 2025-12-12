using Spliit.Core.Entities;

namespace Spliit.Core.Interfaces;

public interface IParticipantRepository : IRepository<Participant>
{
    Task<IEnumerable<Participant>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default);
}

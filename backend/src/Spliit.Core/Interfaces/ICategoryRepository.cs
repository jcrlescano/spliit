using Spliit.Core.Entities;

namespace Spliit.Core.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
}

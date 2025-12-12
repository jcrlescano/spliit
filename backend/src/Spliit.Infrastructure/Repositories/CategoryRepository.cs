using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;

namespace Spliit.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Categories.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }
}

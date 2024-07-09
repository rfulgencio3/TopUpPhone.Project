using Microsoft.EntityFrameworkCore;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;
using TopUpPhone.Infrastructure;

namespace TopUpPhone.Infra.Repositories;

public class TopUpItemRepository : ITopUpItemRepository
{
    private readonly TopUpPhoneDbContext _context;

    public TopUpItemRepository(TopUpPhoneDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TopUpItemEntity>> GetAllAsync()
    {
        return await _context.TopUpItems.ToListAsync();
    }

    public async Task<TopUpItemEntity> GetByIdAsync(int id)
    {
        return await _context.TopUpItems.FindAsync(id);
    }

    public async Task AddAsync(TopUpItemEntity topUpItem)
    {
        await _context.TopUpItems.AddAsync(topUpItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TopUpItemEntity topUpItem)
    {
        _context.TopUpItems.Update(topUpItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TopUpItemEntity topUpItem)
    {
        _context.TopUpItems.Remove(topUpItem);
        await _context.SaveChangesAsync();
    }
}

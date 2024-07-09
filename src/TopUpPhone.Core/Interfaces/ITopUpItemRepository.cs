using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Core.Interfaces;

public interface ITopUpItemRepository
{
    Task<IEnumerable<TopUpItemEntity>> GetAllAsync();
    Task<TopUpItemEntity> GetByIdAsync(int id);
    Task AddAsync(TopUpItemEntity topUpItem);
    Task UpdateAsync(TopUpItemEntity topUpItem);
    Task DeleteAsync(TopUpItemEntity topUpItem);
}

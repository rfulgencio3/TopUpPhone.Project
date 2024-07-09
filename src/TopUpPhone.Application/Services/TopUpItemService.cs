using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.TopUpItem;
using TopUpPhone.Core.Domain.Extensions;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class TopUpItemService : ITopUpItemService
{
    private readonly ITopUpItemRepository _topUpItemRepository;

    public TopUpItemService(ITopUpItemRepository topUpItemRepository)
    {
        _topUpItemRepository = topUpItemRepository;
    }

    public async Task<TopUpItemDTO> GetTopUpItemByIdAsync(int id)
    {
        var topUpItem = await _topUpItemRepository.GetByIdAsync(id);
        if (topUpItem == null) return null;

        return topUpItem.ToDomain();
    }

    public async Task<IEnumerable<TopUpItemDTO>> GetAllTopUpItemsAsync()
    {
        var topUpItems = await _topUpItemRepository.GetAllAsync();
        return topUpItems.Select(t => t.ToDomain());
    }

    public async Task CreateTopUpItemAsync(RequestTopUpItemDTO requestTopUpItemDTO)
    {
        var topUpItem = requestTopUpItemDTO.ToEntity();
        await _topUpItemRepository.AddAsync(topUpItem);
    }

    public async Task UpdateTopUpItemAsync(int id, RequestTopUpItemDTO requestTopUpItemDTO)
    {
        var topUpItem = await _topUpItemRepository.GetByIdAsync(id);
        if (topUpItem == null) return;

        topUpItem.Description = requestTopUpItemDTO.Description;
        topUpItem.Amount = requestTopUpItemDTO.Amount;
        topUpItem.TransactionFee = requestTopUpItemDTO.TransactionFee;
        topUpItem.Status = requestTopUpItemDTO.Status;
        topUpItem.UpdatedAt = DateTime.UtcNow;

        await _topUpItemRepository.UpdateAsync(topUpItem);
    }

    public async Task DeleteTopUpItemAsync(int id)
    {
        var topUpItem = await _topUpItemRepository.GetByIdAsync(id);
        if (topUpItem == null) return;

        await _topUpItemRepository.DeleteAsync(topUpItem);
    }
}

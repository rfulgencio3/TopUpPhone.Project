using TopUpPhone.Application.Common;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.DTOs.TopUpItem;
using TopUpPhone.Core.Domain.Enums;
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

    public async Task<OperationResult<TopUpItemDTO>> GetTopUpItemByIdAsync(int id)
    {
        var topUpItem = await _topUpItemRepository.GetByIdAsync(id);
        if (topUpItem == null)
            return OperationResult<TopUpItemDTO>.Failure("TOPUPITEM_NOT_FOUND");

        return OperationResult<TopUpItemDTO>.SuccessResult(topUpItem.ToDomain());
    }

    public async Task<OperationResult<IEnumerable<TopUpItemDTO>>> GetAllTopUpItemsAsync()
    {
        var topUpItems = await _topUpItemRepository.GetAllAsync();
        if (!topUpItems.Any())
            return OperationResult<IEnumerable<TopUpItemDTO>>.Failure("NO_TOPUPITEM_FOUND");

        return OperationResult<IEnumerable<TopUpItemDTO>>.SuccessResult(topUpItems.Select(t => t.ToDomain()));
    }

    public async Task<OperationResult<bool>> CreateTopUpItemAsync(RequestTopUpItemDTO requestTopUpItemDTO)
    {
        var topUpItem = requestTopUpItemDTO.ToEntity();
        await _topUpItemRepository.AddAsync(topUpItem);
        return OperationResult<bool>.SuccessResult(true);
    }

    public async Task<OperationResult<bool>> UpdateTopUpItemStatusAsync(int id, Status status)
    {
        var topUpItem = await _topUpItemRepository.GetByIdAsync(id);
        if (topUpItem == null)
            return OperationResult<bool>.Failure("TOPUPITEM_NOT_FOUND");

        topUpItem.Status = status;
        topUpItem.UpdatedAt = DateTime.UtcNow;

        await _topUpItemRepository.UpdateAsync(topUpItem);
        return OperationResult<bool>.SuccessResult(true);
    }
}

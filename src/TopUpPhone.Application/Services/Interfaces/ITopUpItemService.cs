using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.DTOs.TopUpItem;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.Services.Interfaces;

public interface ITopUpItemService
{
    Task<OperationResult<TopUpItemDTO>> GetTopUpItemByIdAsync(int id);
    Task<OperationResult<IEnumerable<TopUpItemDTO>>> GetAllTopUpItemsAsync();
    Task<OperationResult<bool>> CreateTopUpItemAsync(RequestTopUpItemDTO requestTopUpItemDTO);
    Task<OperationResult<bool>> UpdateTopUpItemStatusAsync(int id, Status status);
}

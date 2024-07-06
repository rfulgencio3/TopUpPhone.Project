using TopUpPhone.Core.Domain.DTOs.TopUpItem;

namespace TopUpPhone.Application.Services.Interfaces;

public interface ITopUpItemService
{
    Task<TopUpItemDTO> GetTopUpItemByIdAsync(int id);
    Task<IEnumerable<TopUpItemDTO>> GetAllTopUpItemsAsync();
    Task<IAsyncResult> CreateTopUpItemAsync(RequestTopUpItemDTO requestTopUpItemDTO);
    Task<IAsyncResult> UpdateTopUpItemAsync(int id, RequestTopUpItemDTO requestTopUpItemDTO);
    Task<IAsyncResult> DeleteTopUpItemAsync(int id);
}

using TopUpPhone.Core.Domain.DTOs.TopUpItem;

namespace TopUpPhone.Application.Services.Interfaces;

public interface ITopUpItemService
{
    Task<TopUpItemDTO> GetTopUpItemByIdAsync(int id);
    Task<IEnumerable<TopUpItemDTO>> GetAllTopUpItemsAsync();
    Task CreateTopUpItemAsync(RequestTopUpItemDTO requestTopUpItemDTO);
    Task UpdateTopUpItemAsync(int id, RequestTopUpItemDTO requestTopUpItemDTO);
    Task DeleteTopUpItemAsync(int id);
}

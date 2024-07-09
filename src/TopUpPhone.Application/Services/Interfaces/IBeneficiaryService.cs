using TopUpPhone.Core.Domain.DTOs.Beneficiary;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IBeneficiaryService
{
    Task<BeneficiaryDTO> GetBeneficiaryByIdAsync(int id);
    Task<IEnumerable<BeneficiaryDTO>> GetAllBeneficiariesByUserAsync(int userId);
    Task CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO);
    Task UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO);
    Task DeleteBeneficiaryAsync(int id);
}

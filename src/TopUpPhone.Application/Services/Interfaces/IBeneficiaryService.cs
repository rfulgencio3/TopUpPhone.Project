using TopUpPhone.Core.Domain.DTOs.Beneficiary;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IBeneficiaryService
{
    Task<BeneficiaryDTO> GetBeneficiaryByIdAsync(int id);
    Task<IEnumerable<BeneficiaryDTO>> GetAllBeneficiariesByUserAsync();
    Task<IAsyncResult> CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO);
    Task<IAsyncResult> UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO);
    Task<IAsyncResult> DeleteBeneficiaryAsync(int id);
}

using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IBeneficiaryService
{
    Task<OperationResult<BeneficiaryDTO>> GetBeneficiaryByIdAsync(int id);
    Task<OperationResult<IEnumerable<BeneficiaryDTO>>> GetAllBeneficiariesByUserAsync(int userId);
    Task<OperationResult<BeneficiaryDTO>> CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO);
    Task<OperationResult<BeneficiaryDTO>> UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO);
    Task<OperationResult<bool>> DeleteBeneficiaryAsync(int id);
}

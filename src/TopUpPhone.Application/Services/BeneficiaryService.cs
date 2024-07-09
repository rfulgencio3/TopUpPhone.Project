using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.Extensions;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class BeneficiaryService : IBeneficiaryService
{
    private readonly IBeneficiaryRepository _beneficiaryRepository;

    public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository)
    {
        _beneficiaryRepository = beneficiaryRepository;
    }

    public async Task<BeneficiaryDTO> GetBeneficiaryByIdAsync(int id)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) return null;

        return beneficiary.ToDTO();
    }

    public async Task<IEnumerable<BeneficiaryDTO>> GetAllBeneficiariesByUserAsync(int userId)
    {
        var beneficiaries = await _beneficiaryRepository.GetAllByUserIdAsync(userId);
        return beneficiaries.Select(b => b.ToDTO());
    }

    public async Task CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO)
    {
        var beneficiary = createBeneficiaryDTO.ToEntity();
        await _beneficiaryRepository.AddAsync(beneficiary);
    }

    public async Task UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) return;

        beneficiary.Nickname = updateBeneficiaryDTO.Nickname;
        beneficiary.Status = updateBeneficiaryDTO.Status;
        beneficiary.PhoneNumber = updateBeneficiaryDTO.PhoneNumber;
        beneficiary.UpdatedAt = DateTime.UtcNow;

        await _beneficiaryRepository.UpdateAsync(beneficiary);
    }

    public async Task DeleteBeneficiaryAsync(int id)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) return;

        await _beneficiaryRepository.DeleteAsync(beneficiary);
    }
}

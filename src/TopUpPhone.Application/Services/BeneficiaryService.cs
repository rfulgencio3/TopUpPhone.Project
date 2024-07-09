using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Domain.Extensions;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class BeneficiaryService : IBeneficiaryService
{
    private readonly IBeneficiaryRepository _beneficiaryRepository;
    private readonly IUserRepository _userRepository;

    public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository, IUserRepository userRepository)
    {
        _beneficiaryRepository = beneficiaryRepository;
        _userRepository = userRepository;
    }

    public async Task<BeneficiaryDTO> GetBeneficiaryByIdAsync(int id)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) return null;

        return beneficiary.ToDomain();
    }

    public async Task<IEnumerable<BeneficiaryDTO>> GetAllBeneficiariesByUserAsync(int userId)
    {
        var beneficiaries = await _beneficiaryRepository.GetAllByUserIdAsync(userId);
        return beneficiaries.Select(b => b.ToDomain());
    }

    public async Task CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO)
    {
        var user = await _userRepository.GetByIdAsync(createBeneficiaryDTO.UserId);
        if (user == null) throw new Exception("User not found");

        var beneficiary = createBeneficiaryDTO.ToEntity(user.Id);
        await _beneficiaryRepository.AddAsync(beneficiary);
    }

    public async Task UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) throw new Exception("Beneficiary not found");

        var user = await _userRepository.GetByIdAsync(updateBeneficiaryDTO.UserId);
        if (user == null) throw new Exception("User not found");

        CreateBeneficiaryObject(updateBeneficiaryDTO, beneficiary);

        await _beneficiaryRepository.UpdateAsync(beneficiary);
    }

    public async Task DeleteBeneficiaryAsync(int id)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null) throw new Exception("Beneficiary not found");

        await _beneficiaryRepository.DeleteAsync(beneficiary);
    }
    
    private static void CreateBeneficiaryObject(RequestBeneficiaryDTO updateBeneficiaryDTO, BeneficiaryEntity beneficiary)
    {
        beneficiary.Nickname = updateBeneficiaryDTO.Nickname;
        beneficiary.Status = updateBeneficiaryDTO.Status;
        beneficiary.PhoneNumber = updateBeneficiaryDTO.PhoneNumber;
        beneficiary.UserId = updateBeneficiaryDTO.UserId;
        beneficiary.UpdatedAt = DateTime.UtcNow;
    }
}

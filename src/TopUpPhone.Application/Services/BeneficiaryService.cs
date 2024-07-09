using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Extensions;
using TopUpPhone.Application.Services.Interfaces;
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

    public async Task<OperationResult<BeneficiaryDTO>> GetBeneficiaryByIdAsync(int id)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null)
            return OperationResult<BeneficiaryDTO>.Failure("BENEFICIARY_NOT_FOUND");

        return OperationResult<BeneficiaryDTO>.SuccessResult(beneficiary.ToDomain());
    }

    public async Task<OperationResult<IEnumerable<BeneficiaryDTO>>> GetAllBeneficiariesByUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            return OperationResult<IEnumerable<BeneficiaryDTO>>.Failure("USER_NOT_FOUND");

        var beneficiaries = await _beneficiaryRepository.GetAllByUserIdAsync(userId);
        if (!beneficiaries.Any())
            return OperationResult<IEnumerable<BeneficiaryDTO>>.Failure("NO_BENEFICIARIES_FOUND");

        return OperationResult<IEnumerable<BeneficiaryDTO>>.SuccessResult(beneficiaries.Select(b => b.ToDomain()));
    }

    public async Task<OperationResult<BeneficiaryDTO>> CreateBeneficiaryAsync(RequestBeneficiaryDTO createBeneficiaryDTO)
    {
        var user = await _userRepository.GetByIdAsync(createBeneficiaryDTO.UserId);
        if (user == null)
            return OperationResult<BeneficiaryDTO>.Failure("USER_NOT_FOUND");

        var beneficiaryByUserCount = await _beneficiaryRepository.CountByUserIdAsync(user.Id);
        if (beneficiaryByUserCount >= 5)
            return OperationResult<BeneficiaryDTO>.Failure("USER_ALREAD_WITH_MAXIMUN_OF_ACTIVE_BENEFICIARIES");

        var beneficiary = createBeneficiaryDTO.ToEntity(user.Id);
        await _beneficiaryRepository.AddAsync(beneficiary);

        return OperationResult<BeneficiaryDTO>.SuccessResult(beneficiary.ToDomain());
    }

    public async Task<OperationResult<BeneficiaryDTO>> UpdateBeneficiaryAsync(int id, UpdateBeneficiaryDTO updateBeneficiaryDTO)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null)
            return OperationResult<BeneficiaryDTO>.Failure("BENEFICIARY_NOT_FOUND");

        var user = await _userRepository.GetByIdAsync(beneficiary.UserId);
        if (user == null)
            return OperationResult<BeneficiaryDTO>.Failure("USER_NOT_FOUND");

        await _beneficiaryRepository.UpdateAsync(beneficiary);
        return OperationResult<BeneficiaryDTO>.SuccessResult(beneficiary.ToDomain());
    }
}

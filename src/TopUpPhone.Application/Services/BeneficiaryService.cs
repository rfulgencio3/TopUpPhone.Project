using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Extensions;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.Entities;
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

        var beneficiary = createBeneficiaryDTO.ToEntity(user.Id);
        await _beneficiaryRepository.AddAsync(beneficiary);
        return OperationResult<BeneficiaryDTO>.SuccessResult(beneficiary.ToDomain());
    }

    public async Task<OperationResult<BeneficiaryDTO>> UpdateBeneficiaryAsync(int id, RequestBeneficiaryDTO updateBeneficiaryDTO)
    {
        var beneficiary = await _beneficiaryRepository.GetByIdAsync(id);
        if (beneficiary == null)
            return OperationResult<BeneficiaryDTO>.Failure("BENEFICIARY_NOT_FOUND");

        var user = await _userRepository.GetByIdAsync(updateBeneficiaryDTO.UserId);
        if (user == null)
            return OperationResult<BeneficiaryDTO>.Failure("USER_NOT_FOUND");

        CreateBeneficiaryObject(updateBeneficiaryDTO, beneficiary);

        await _beneficiaryRepository.UpdateAsync(beneficiary);
        return OperationResult<BeneficiaryDTO>.SuccessResult(beneficiary.ToDomain());
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

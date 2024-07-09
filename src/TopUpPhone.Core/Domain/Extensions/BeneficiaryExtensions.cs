using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Core.Domain.Extensions;

public static class BeneficiaryEntityExtensions
{
    public static BeneficiaryDTO ToDomain(this BeneficiaryEntity beneficiaryEntity)
    {
        return new BeneficiaryDTO
        {
            Nickname = beneficiaryEntity.Nickname,
            TopUpBalance = beneficiaryEntity.TopUpBalance,
            Status = beneficiaryEntity.Status,
            PhoneNumber = beneficiaryEntity.PhoneNumber
        };
    }

    public static BeneficiaryEntity ToEntity(this RequestBeneficiaryDTO requestBeneficiaryDTO, int userId)
    {
        return new BeneficiaryEntity
        {
            Nickname = requestBeneficiaryDTO.Nickname,
            Status = requestBeneficiaryDTO.Status,
            PhoneNumber = requestBeneficiaryDTO.PhoneNumber,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };
    }
}

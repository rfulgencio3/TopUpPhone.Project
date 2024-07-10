using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Helpers;
using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Application.Extensions;

public static class BeneficiaryEntityExtensions
{
    public static BeneficiaryDTO ToDomain(this BeneficiaryEntity entity)
    {
        return new BeneficiaryDTO
        {
            Id = entity.Id,
            UserId = entity.UserId,
            Nickname = entity.Nickname,
            TopUpBalance = entity.TopUpBalance,
            Status = entity.Status,
            PhoneNumber = entity.PhoneNumber
        };
    }

    public static BeneficiaryEntity ToEntity(this RequestBeneficiaryDTO dto, int userId)
    {
        return new BeneficiaryEntity
        {
            Nickname = dto.Nickname,
            Status = EnumHelper.ConvertToStatus(dto.Status),
            PhoneNumber = dto.PhoneNumber,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };
    }
}

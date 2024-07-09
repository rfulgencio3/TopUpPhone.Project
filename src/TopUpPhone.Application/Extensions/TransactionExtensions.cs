using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Application.Extensions;

public static class TransactionExtensions
{
    public static TransactionDTO ToDomain(this TransactionEntity entity)
    {
        return new TransactionDTO
        {
            Id = entity.Id,
            BeneficiaryId = entity.BeneficiaryId,
            TopUpItemId = entity.TopUpItemId,
            Amount = entity.Amount,
            TransactionFee = entity.TransactionFee,
            BeneficiaryBalance = 0
        };
    }

    public static TransactionEntity ToEntity(this RequestTransactionDTO dto)
    {
        return new TransactionEntity
        {
            BeneficiaryId = dto.BeneficiaryId,
            TopUpItemId = dto.TopUpItemId,
            Amount = 0,
            TransactionFee = 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}

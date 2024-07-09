using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Application.Extensions;

public static class TopUpItemEntityExtensions
{
    public static TopUpItemDTO ToDomain(this TopUpItemEntity topUpItemEntity)
    {
        return new TopUpItemDTO
        {
            Id = topUpItemEntity.Id,
            Description = topUpItemEntity.Description,
            Amount = topUpItemEntity.Amount,
            TransactionFee = topUpItemEntity.TransactionFee,
            Status = topUpItemEntity.Status
        };
    }

    public static TopUpItemEntity ToEntity(this RequestTopUpItemDTO requestTopUpItemDTO)
    {
        return new TopUpItemEntity
        {
            Description = requestTopUpItemDTO.Description,
            Amount = requestTopUpItemDTO.Amount,
            TransactionFee = requestTopUpItemDTO.TransactionFee,
            Status = requestTopUpItemDTO.Status,
            CreatedAt = DateTime.UtcNow
        };
    }
}

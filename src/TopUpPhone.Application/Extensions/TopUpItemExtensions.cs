using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Helpers;
using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Application.Extensions;

public static class TopUpItemEntityExtensions
{
    public static TopUpItemDTO ToDomain(this TopUpItemEntity entity)
    {
        return new TopUpItemDTO
        {
            Id = entity.Id,
            Description = entity.Description,
            Amount = entity.Amount,
            TransactionFee = entity.TransactionFee,
            Status = entity.Status
        };
    }

    public static TopUpItemEntity ToEntity(this RequestTopUpItemDTO dto)
    {
        return new TopUpItemEntity
        {
            Description = dto.Description,
            Amount = dto.Amount,
            TransactionFee = dto.TransactionFee,
            Status = EnumHelper.ConvertToStatus(dto.Status),
            CreatedAt = DateTime.UtcNow
        };
    }
}

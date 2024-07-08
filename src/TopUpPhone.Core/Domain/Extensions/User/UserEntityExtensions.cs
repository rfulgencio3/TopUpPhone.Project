using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.DTOs.User;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.Extensions;

public static class UserEntityExtensions
{
    public static UserDTO ToDomain(this UserEntity entity)
    {
        return new UserDTO
        {
            Id = entity.Id,
            UserName = entity.UserName,
            Balance = entity.Balance,
            Status = entity.Status,
            IsVerified = entity.IsVerified
        };
    }

    public static UserEntity ToEntity(this RequestUserDTO dto)
    {
        return new UserEntity
        {
            UserName = dto.Name,
            Balance = dto.Balance,
            IsVerified = dto.IsVerified,
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow
        };
    }
}

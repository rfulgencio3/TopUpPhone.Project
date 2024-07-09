using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Core.Interfaces;
public interface IUserRepository
{
    Task<UserEntity> GetByIdAsync(int id);
    Task AddAsync(UserEntity user);
    Task UpdateAsync(UserEntity user);
}

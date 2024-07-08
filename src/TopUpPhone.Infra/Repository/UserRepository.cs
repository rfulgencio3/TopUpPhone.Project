using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Domain.Repositories;

namespace TopUpPhone.Infra.Repository;

public class UserRepository : IUserRepository
{
    public Task AddAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }
}

using Microsoft.EntityFrameworkCore;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;
using TopUpPhone.Infrastructure;

namespace TopUpPhone.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TopUpPhoneDbContext _context;

    public UserRepository(TopUpPhoneDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserEntity user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserEntity> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Beneficiaries)
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(UserEntity user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}

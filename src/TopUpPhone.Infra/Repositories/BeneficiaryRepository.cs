using Microsoft.EntityFrameworkCore;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;
using TopUpPhone.Infrastructure;

namespace TopUpPhone.Infra.Repositories;

public class BeneficiaryRepository : IBeneficiaryRepository
{
    private readonly TopUpPhoneDbContext _context;

    public BeneficiaryRepository(TopUpPhoneDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BeneficiaryEntity>> GetAllByUserIdAsync(int userId)
    {
        return await _context.Beneficiaries
                             .Where(b => b.User.Id == userId)
                             .ToListAsync();
    }

    public async Task<BeneficiaryEntity> GetByIdAsync(int id)
    {
        return await _context.Beneficiaries.FindAsync(id);
    }

    public async Task AddAsync(BeneficiaryEntity beneficiary)
    {
        await _context.Beneficiaries.AddAsync(beneficiary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BeneficiaryEntity beneficiary)
    {
        _context.Beneficiaries.Update(beneficiary);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BeneficiaryEntity beneficiary)
    {
        _context.Beneficiaries.Remove(beneficiary);
        await _context.SaveChangesAsync();
    }
}

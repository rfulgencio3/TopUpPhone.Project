using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Core.Interfaces;

public interface IBeneficiaryRepository
{
    Task<IEnumerable<BeneficiaryEntity>> GetAllByUserIdAsync(int userId);
    Task<BeneficiaryEntity> GetByIdAsync(int id);
    Task AddAsync(BeneficiaryEntity beneficiary);
    Task UpdateAsync(BeneficiaryEntity beneficiary);
    Task<int> CountByUserIdAsync(int userId);
}

using TopUpPhone.Core.Domain.Entities;

namespace TopUpPhone.Core.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(TransactionEntity transaction);
    Task<decimal> GetTotalAmountByBeneficiaryAsync(int beneficiaryId, DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalAmountByUserAsync(int userId, DateTime startDate, DateTime endDate);
}

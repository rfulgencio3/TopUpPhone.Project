using Microsoft.EntityFrameworkCore;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;
using TopUpPhone.Infrastructure;

namespace TopUpPhone.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TopUpPhoneDbContext _context;

        public TransactionRepository(TopUpPhoneDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TransactionEntity transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalAmountByBeneficiaryAsync(int beneficiaryId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.BeneficiaryId == beneficiaryId && t.CreatedAt >= startDate && t.CreatedAt <= endDate)
                .SumAsync(t => t.Amount);
        }

        public async Task<decimal> GetTotalAmountByUserAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.Beneficiary.UserId == userId && t.CreatedAt >= startDate && t.CreatedAt <= endDate)
                .SumAsync(t => t.Amount);
        }
    }
}

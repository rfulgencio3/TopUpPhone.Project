using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Validators
{
    public class TransactionValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly ITopUpItemRepository _topUpItemRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionValidator(
            IUserRepository userRepository,
            IBeneficiaryRepository beneficiaryRepository,
            ITopUpItemRepository topUpItemRepository,
            ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _beneficiaryRepository = beneficiaryRepository;
            _topUpItemRepository = topUpItemRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<OperationResult<(UserEntity User, BeneficiaryEntity Beneficiary, TopUpItemEntity TopUpItem)>> ValidateAsync(RequestTransactionDTO requestTransactionDTO)
        {
            var userResult = await ValidateUserAsync(requestTransactionDTO.UserId);
            if (!userResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(userResult.ErrorMessage);

            var beneficiaryResult = await ValidateBeneficiaryAsync(requestTransactionDTO.BeneficiaryId, userResult.Data);
            if (!beneficiaryResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(beneficiaryResult.ErrorMessage);

            var topUpItemResult = await ValidateTopUpItemAsync(requestTransactionDTO.TopUpItemId);
            if (!topUpItemResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(topUpItemResult.ErrorMessage);

            var balanceResult = ValidateUserBalance(userResult.Data, topUpItemResult.Data);
            if (!balanceResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(balanceResult.ErrorMessage);

            var beneficiaryCountResult = await ValidateBeneficiaryCountAsync(userResult.Data);
            if (!beneficiaryCountResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(beneficiaryCountResult.ErrorMessage);

            var monthlyLimitResult = await ValidateMonthlyLimitAsync(userResult.Data, beneficiaryResult.Data, topUpItemResult.Data.Amount);
            if (!monthlyLimitResult.Success)
                return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.Failure(monthlyLimitResult.ErrorMessage);

            return OperationResult<(UserEntity, BeneficiaryEntity, TopUpItemEntity)>.SuccessResult((userResult.Data, beneficiaryResult.Data, topUpItemResult.Data));
        }

        private async Task<OperationResult<UserEntity>> ValidateUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return OperationResult<UserEntity>.Failure("USER_NOT_FOUND");

            return OperationResult<UserEntity>.SuccessResult(user);
        }

        private async Task<OperationResult<BeneficiaryEntity>> ValidateBeneficiaryAsync(int beneficiaryId, UserEntity user)
        {
            var beneficiary = await _beneficiaryRepository.GetByIdAsync(beneficiaryId);
            if (beneficiary == null || beneficiary.UserId != user.Id)
                return OperationResult<BeneficiaryEntity>.Failure("BENEFICIARY_NOT_FOUND_OR_NOT_ASSOCIATED_WITH_USER");

            return OperationResult<BeneficiaryEntity>.SuccessResult(beneficiary);
        }

        private async Task<OperationResult<TopUpItemEntity>> ValidateTopUpItemAsync(int topUpItemId)
        {
            var topUpItem = await _topUpItemRepository.GetByIdAsync(topUpItemId);
            if (topUpItem == null)
                return OperationResult<TopUpItemEntity>.Failure("TOPUP_ITEM_NOT_FOUND");

            return OperationResult<TopUpItemEntity>.SuccessResult(topUpItem);
        }

        private OperationResult<bool> ValidateUserBalance(UserEntity user, TopUpItemEntity topUpItem)
        {
            if (user.Balance < topUpItem.Amount + topUpItem.TransactionFee)
                return OperationResult<bool>.Failure("INSUFFICIENT_BALANCE");

            return OperationResult<bool>.SuccessResult(true);
        }

        private async Task<OperationResult<bool>> ValidateBeneficiaryCountAsync(UserEntity user)
        {
            var beneficiaryCount = await _beneficiaryRepository.CountByUserIdAsync(user.Id);
            if (beneficiaryCount >= 5)
                return OperationResult<bool>.Failure("MAX_BENEFICIARIES_REACHED");

            return OperationResult<bool>.SuccessResult(true);
        }

        private async Task<OperationResult<bool>> ValidateMonthlyLimitAsync(UserEntity user, BeneficiaryEntity beneficiary, decimal amount)
        {
            var currentMonth = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var beneficiaryMonthlyTotal = await _transactionRepository.GetTotalAmountByBeneficiaryAsync(beneficiary.Id, firstDayOfMonth, lastDayOfMonth);
            var userMonthlyTotal = await _transactionRepository.GetTotalAmountByUserAsync(user.Id, firstDayOfMonth, lastDayOfMonth);

            var beneficiaryLimit = user.IsVerified ? 1000 : 500;
            if (beneficiaryMonthlyTotal + amount > beneficiaryLimit)
                return OperationResult<bool>.Failure("BENEFICIARY_MONTHLY_LIMIT_EXCEEDED");

            if (userMonthlyTotal + amount > 3000)
                return OperationResult<bool>.Failure("USER_MONTHLY_LIMIT_EXCEEDED");

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}

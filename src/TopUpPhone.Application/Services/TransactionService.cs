using System.Net.Http;
using System.Threading.Tasks;
using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Extensions;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Application.Validators;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IUserRepository _userRepository;
    private readonly IBeneficiaryRepository _beneficiaryRepository;
    private readonly ITopUpItemRepository _topUpItemRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionValidator _transactionValidator;
    private readonly HttpClient _httpClient;

    public TransactionService(
        IUserRepository userRepository,
        IBeneficiaryRepository beneficiaryRepository,
        ITopUpItemRepository topUpItemRepository,
        ITransactionRepository transactionRepository,
        TransactionValidator transactionValidator,
        HttpClient httpClient)
    {
        _userRepository = userRepository;
        _beneficiaryRepository = beneficiaryRepository;
        _topUpItemRepository = topUpItemRepository;
        _transactionRepository = transactionRepository;
        _transactionValidator = transactionValidator;
        _httpClient = httpClient;   
    }

    public async Task<OperationResult<TransactionDTO>> CreateTransactionAsync(RequestTransactionDTO requestTransactionDTO)
    {
        var validationResult = await _transactionValidator.ValidateAsync(requestTransactionDTO);
        if (!validationResult.Success)
            return OperationResult<TransactionDTO>.Failure(validationResult.ErrorMessage);

        var (user, beneficiary, topUpItem) = validationResult.Data;

        var originalUserBalance = user.Balance;

        var transaction = requestTransactionDTO.ToEntity();
        transaction.Amount = topUpItem.Amount;
        transaction.TransactionFee = topUpItem.TransactionFee;

        user.Balance -= transaction.Amount;
        beneficiary.TopUpBalance += (transaction.Amount - transaction.TransactionFee);

        try
        {
            await _userRepository.UpdateAsync(user);
            await _transactionRepository.AddAsync(transaction);
            await _beneficiaryRepository.UpdateAsync(beneficiary);
        }
        catch (Exception ex)
        {
            // Revert user balance in case of error
            user.Balance = originalUserBalance;
            await _userRepository.UpdateAsync(user);
            return OperationResult<TransactionDTO>.Failure("TRANSACTION_FAILED: " + ex.Message);
        }

        var beneficiaryBalance = await GetBeneficiaryBalanceAsync(beneficiary.Id);

        var transactionDTO = transaction.ToDomain();
        transactionDTO.BeneficiaryBalance = beneficiaryBalance;

        return OperationResult<TransactionDTO>.SuccessResult(transactionDTO);
    }
    private async Task<decimal> GetBeneficiaryBalanceAsync(int beneficiaryId)
    {
        var response = await _httpClient.GetAsync($"api/beneficiary/{beneficiaryId}");
        response.EnsureSuccessStatusCode();

        var beneficiary = await response.Content.ReadAsAsync<BeneficiaryDTO>();
        return beneficiary.TopUpBalance;
    }
}

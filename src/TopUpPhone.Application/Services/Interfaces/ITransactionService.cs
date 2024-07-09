using System.Threading.Tasks;
using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;

namespace TopUpPhone.Application.Services.Interfaces;

public interface ITransactionService
{
    Task<OperationResult<TransactionDTO>> CreateTransactionAsync(RequestTransactionDTO requestTransactionDTO);
}

using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IUserService
{
    Task<OperationResult<UserDTO>> GetUserByIdAsync(int id);
    Task<OperationResult<UserDTO>> CreateUserAsync(RequestUserDTO createUserDTO);
    Task<OperationResult<bool>> UpdateIsVerifiedAsync(int id, bool isVerified);
    Task<OperationResult<bool>> IncrementBalanceAsync(int id, decimal amount);
}

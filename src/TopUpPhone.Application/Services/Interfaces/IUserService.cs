using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.DTOs.User;

namespace TopUpPhone.Application.Services.Interfaces;
public interface IUserService
{
    Task<OperationResult<UserDTO>> GetUserByIdAsync(int id);
    Task<OperationResult<bool>> CreateUserAsync(RequestUserDTO createUserDTO);
    Task<OperationResult<bool>> UpdateIsVerifiedAsync(int id, bool isVerified);
}

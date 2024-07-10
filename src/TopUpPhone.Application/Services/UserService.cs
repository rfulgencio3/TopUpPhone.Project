using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Extensions;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Domain.Enums;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<UserDTO>> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return OperationResult<UserDTO>.Failure("USER_NOT_FOUND");

        return OperationResult<UserDTO>.SuccessResult(user.ToDomain());
    }

    public async Task<OperationResult<UserDTO>> CreateUserAsync(RequestUserDTO createUserDTO)
    {
        if (!Enum.TryParse(createUserDTO.Status, true, out Status status))
        {
            return OperationResult<UserDTO>.Failure("INVALID_STATUS");
        }

        var user = new UserEntity
        {
            UserName = createUserDTO.Name,
            Balance = createUserDTO.Balance,
            Status = status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);

        return OperationResult<UserDTO>.SuccessResult(user.ToDomain());
    }

    public async Task<OperationResult<bool>> UpdateIsVerifiedAsync(int id, bool isVerified)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return OperationResult<bool>.Failure("USER_NOT_FOUND");

        user.IsVerified = isVerified;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        return OperationResult<bool>.SuccessResult(true);
    }

    public async Task<OperationResult<bool>> IncrementBalanceAsync(int id, decimal amount)
    {
        if (amount <= 0)
            return OperationResult<bool>.Failure("AMOUNT_MUST_BE_POSITIVE");

        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return OperationResult<bool>.Failure("USER_NOT_FOUND");

        user.Balance += amount;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        return OperationResult<bool>.SuccessResult(true);
    }
}

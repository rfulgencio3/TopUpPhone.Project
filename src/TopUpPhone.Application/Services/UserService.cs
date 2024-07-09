using TopUpPhone.Application.Common;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.User;
using TopUpPhone.Core.Domain.Extensions;
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

    public async Task<OperationResult<bool>> CreateUserAsync(RequestUserDTO createUserDTO)
    {
        var user = createUserDTO.ToEntity();
        await _userRepository.AddAsync(user);
        return OperationResult<bool>.SuccessResult(true);
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
}

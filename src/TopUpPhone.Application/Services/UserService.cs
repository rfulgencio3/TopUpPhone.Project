using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.DTOs.User;
using TopUpPhone.Core.Interfaces;

namespace TopUpPhone.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IAsyncResult> CreateUserAsync(RequestUserDTO createUserDTO)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetCustomerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetCustomerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncResult> UpdateUserAsync(RequestUserDTO requestUserDTO)
    {
        throw new NotImplementedException();
    }
}

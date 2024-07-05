using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs;
using TopUpPhone.Core.Domain.Interfaces;

namespace TopUpPhone.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IAsyncResult> CreateUserAsync(CreateUserDTO createUserDTO)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetCustomerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

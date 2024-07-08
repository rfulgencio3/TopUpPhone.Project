using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.User;
using TopUpPhone.Core.Domain.Extensions;
using TopUpPhone.Core.Domain.Repositories;

namespace TopUpPhone.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return user.ToDomain();
    }

    public async Task CreateUserAsync(RequestUserDTO createUserDTO)
    {
        var user = createUserDTO.ToEntity();
        await _userRepository.AddAsync(user);
    }
}

using TopUpPhone.Core.Domain.DTOs.User;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetUserByIdAsync(int id);
    Task CreateUserAsync(RequestUserDTO createUserDTO);
}

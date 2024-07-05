using TopUpPhone.Core.Domain.DTOs;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetCustomerByIdAsync(Guid id);
    Task<IAsyncResult> CreateUserAsync(CreateUserDTO createUserDTO);
}

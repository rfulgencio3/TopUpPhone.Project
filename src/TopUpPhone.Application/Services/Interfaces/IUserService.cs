using TopUpPhone.Core.Domain.DTOs.Beneficiary;
using TopUpPhone.Core.Domain.DTOs.User;

namespace TopUpPhone.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetCustomerByIdAsync(int id);
    Task<IAsyncResult> CreateUserAsync(RequestUserDTO requestUserDTO);
    Task<IAsyncResult> UpdateUserAsync(RequestUserDTO requestUserDTO);
}

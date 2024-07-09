using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestUserDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public bool IsVerified { get; set; }
    public Status Status { get; set; }
}

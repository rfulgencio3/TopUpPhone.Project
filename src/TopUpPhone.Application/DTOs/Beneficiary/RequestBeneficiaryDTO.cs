using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestBeneficiaryDTO
{
    public string Nickname { get; set; }
    public Status Status { get; set; } = Status.Active;
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
}

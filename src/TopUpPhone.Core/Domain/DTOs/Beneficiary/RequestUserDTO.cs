using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.Beneficiary;

public class RequestUserDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public Status Status { get; set; }
}

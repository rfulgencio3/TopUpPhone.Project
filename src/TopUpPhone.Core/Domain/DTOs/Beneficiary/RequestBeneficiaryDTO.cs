using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.Beneficiary;

public class RequestBeneficiaryDTO
{
    public string Nickname { get; set; }
    public Status Status { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
}

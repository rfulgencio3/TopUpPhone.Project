using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.Entities;

public class BeneficiaryEntity : Base
{
    public string Nickname { get; set; }
    public decimal TopUpBalance { get; set; }
    public Status Status { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}

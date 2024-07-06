using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.Beneficiary;

public class BeneficiaryDTO
{
    public string Nickname { get; set; }
    public decimal TopUpBalance { get; set; }
    public Status Status { get; set; }
    public string PhoneNumber { get; set; }
}

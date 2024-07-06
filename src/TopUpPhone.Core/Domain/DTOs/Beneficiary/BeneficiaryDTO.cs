using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.DTOs.TopUpItem;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.Beneficiary;

public class BeneficiaryDTO
{
    [MaxLength(20, ErrorMessage = "The Nickname field must not exceed {1} characters. Currently, it has {0} characters.")]
    public string Nickname { get; set; }
    public decimal TopUpBalance { get; set; }
    public Status Status { get; set; }
    public string PhoneNumber { get; set; }
}

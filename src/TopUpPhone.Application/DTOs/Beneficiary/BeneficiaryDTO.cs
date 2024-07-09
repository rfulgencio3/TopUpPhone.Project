using System.ComponentModel.DataAnnotations;
using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class BeneficiaryDTO
{
    public int Id { get; set; }
    [MaxLength(20, ErrorMessage = "The Nickname field must not exceed {1} characters. Currently, it has {0} characters.")]
    public string Nickname { get; set; }
    public decimal TopUpBalance { get; set; }
    public Status Status { get; set; }
    public string PhoneNumber { get; set; }
    public List<LinkHelper> Links { get; set; } = new List<LinkHelper>();
}

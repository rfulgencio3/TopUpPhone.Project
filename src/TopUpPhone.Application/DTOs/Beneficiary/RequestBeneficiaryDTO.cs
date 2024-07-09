using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestBeneficiaryDTO
{
    [MaxLength(20, ErrorMessage = "The Nickname field must not exceed {1} characters. Currently, it has {0} characters.")]
    public string Nickname { get; set; }
    public Status Status { get; set; } = Status.Active;
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
}

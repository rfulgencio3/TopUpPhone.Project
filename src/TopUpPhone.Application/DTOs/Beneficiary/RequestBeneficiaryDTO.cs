using System.ComponentModel.DataAnnotations;

namespace TopUpPhone.Application.DTOs;

public class RequestBeneficiaryDTO
{
    public string Nickname { get; set; }
    [Required]
    public string Status { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
}

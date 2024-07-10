using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class UpdateBeneficiaryDTO
{
    [MaxLength(20, ErrorMessage = "The Nickname field must not exceed {1} characters. Currently, it has {0} characters.")]
    public string Nickname { get; set; }
    [EnumDataType(typeof(Status), ErrorMessage = "STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.")]
    [Required]
    public string Status { get; set; }
    public string PhoneNumber { get; set; }
}

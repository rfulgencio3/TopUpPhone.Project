using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestUserDTO
{
    public string Name { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "BALANCE_MUST_BE_POSITIVE")]
    public decimal Balance { get; set; }
    [EnumDataType(typeof(Status), ErrorMessage = "STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.")]
    public Status Status { get; set; }
}

using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestUserDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "BALANCE_MUST_BE_POSITIVE")]
    public decimal Balance { get; set; }
    public Status Status { get; set; }
}

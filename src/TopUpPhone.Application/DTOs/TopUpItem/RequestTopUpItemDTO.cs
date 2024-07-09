using System.ComponentModel.DataAnnotations;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestTopUpItemDTO
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    [EnumDataType(typeof(Status), ErrorMessage = "STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.")]
    public Status Status { get; set; } = Status.Active;
}

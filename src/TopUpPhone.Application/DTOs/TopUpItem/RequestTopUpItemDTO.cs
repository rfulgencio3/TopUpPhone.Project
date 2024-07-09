using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class RequestTopUpItemDTO
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    public Status Status { get; set; } = Status.Active;
}

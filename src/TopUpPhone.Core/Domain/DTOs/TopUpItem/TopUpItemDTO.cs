using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.TopUpItem;

public class TopUpItemDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    public Status Status { get; set; }
}

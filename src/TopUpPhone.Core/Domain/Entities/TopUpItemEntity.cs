using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.Entities;

public class TopUpItemEntity : Base
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    public Status Status { get; set; }
}

using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class TopUpItemDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    public Status Status { get; set; }
    public List<LinkHelper> Links { get; set; } = new List<LinkHelper>();
}

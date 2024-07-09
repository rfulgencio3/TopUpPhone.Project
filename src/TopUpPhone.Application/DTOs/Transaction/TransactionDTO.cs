using TopUpPhone.Application.Common;

namespace TopUpPhone.Application.DTOs;

public class TransactionDTO
{
    public int Id { get; set; }
    public int BeneficiaryId { get; set; }
    public int TopUpItemId { get; set; }
    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
    public decimal BeneficiaryBalance { get; set; }
    public List<LinkHelper> Links { get; set; } = new List<LinkHelper>();
}

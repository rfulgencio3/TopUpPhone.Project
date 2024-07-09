namespace TopUpPhone.Core.Domain.Entities;

public class TransactionEntity : Base
{
    public int BeneficiaryId { get; set; }
    public BeneficiaryEntity Beneficiary { get; set; }

    public int TopUpItemId { get; set; }    
    public TopUpItemEntity TopUpItem { get; set; }

    public decimal Amount { get; set; }
    public decimal TransactionFee { get; set; }
}

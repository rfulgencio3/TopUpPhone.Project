namespace TopUpPhone.Core.Domain.Entities;

public class TransactionEntity : Base
{
    public string Description { get; set; }
    public UserEntity User { get; set; }
    public BeneficiaryEntity Beneficiary { get; set; }
    public TopUpItemEntity TopUpItem { get; set; }
}

using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.Entities;

public class UserEntity : Base
{
    public string UserName { get; set; }
    public IEnumerable<BeneficiaryEntity> Beneficiaries { get; set; }
    public decimal Balance { get; set; }
    public Status Status { get; set; }
    public bool IsVerified { get; set; }
}

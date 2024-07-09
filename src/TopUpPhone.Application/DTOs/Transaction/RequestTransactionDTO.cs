namespace TopUpPhone.Application.DTOs;

public class RequestTransactionDTO
{
    public int UserId { get; set; }
    public int BeneficiaryId { get; set; }
    public int TopUpItemId { get; set; }
}

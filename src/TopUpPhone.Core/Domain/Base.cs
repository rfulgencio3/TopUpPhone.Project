namespace TopUpPhone.Core.Domain;

public class Base
{
    Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

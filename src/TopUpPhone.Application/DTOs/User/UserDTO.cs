using TopUpPhone.Application.Common;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public Status Status { get; set; } = Status.Active;
    public bool IsVerified { get; set; }
    public decimal Balance { get; set; }
    public List<LinkHelper> Links { get; set; } = new List<LinkHelper>();
}

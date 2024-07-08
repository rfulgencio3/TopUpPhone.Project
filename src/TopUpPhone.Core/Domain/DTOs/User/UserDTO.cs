using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Core.Domain.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public Status Status { get; set; }
        public bool IsVerified { get; set; }
    }
}

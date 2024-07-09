using System.Runtime.Serialization;

namespace TopUpPhone.Core.Domain.Enums
{
    public enum Status
    {
        [EnumMember(Value = "Active")]
        Active = 1,
        [EnumMember(Value = "Inactive")]
        Inactive = 0
    }
}

using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.Helpers;
public static class EnumHelper
{
    public static Status ConvertToStatus(string status)
    {
        if (!Enum.TryParse(status, true, out Status result))
        {
            throw new ArgumentException("INVALID_STATUS_VALUE");
        }
        return result;
    }
}

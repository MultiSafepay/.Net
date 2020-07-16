using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    public enum NotificationMethod
    {
        [EnumMember(Value = "GET")]
        GET,
        [EnumMember(Value = "POST")]
        POST
    }
}

using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    internal enum NotificationMethod
    {
        [EnumMember(Value = "GET")]
        GET,
        [EnumMember(Value = "POST")]
        POST
    }
}
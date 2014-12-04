using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    internal enum OrderType
    {
        [EnumMember(Value = "direct")]
        Direct,
        [EnumMember(Value = "redirect")]
        Redirect,
        [EnumMember(Value = "checkout")]
        FastCheckout
    }
}
using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    internal enum PaymentFlow
    {
        [EnumMember(Value = "direct")]
        Direct,
        [EnumMember(Value = "redirect")]
        Redirect,
        [EnumMember(Value = "checkout")]
        FastCheckout
    }
}
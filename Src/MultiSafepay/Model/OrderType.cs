using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    public enum OrderType
    {
        [EnumMember(Value = "direct")]
        Direct,
        [EnumMember(Value = "redirect")]
        Redirect,
        [EnumMember(Value = "checkout")]
        FastCheckout,
        [EnumMember(Value = "paymentlink")]
        PaymentLink
    }
}
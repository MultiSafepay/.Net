using System.Runtime.Serialization;

namespace MultiSafepay.Model
{
    public enum PaymentFlow
    {
        [EnumMember(Value = "direct")]
        Direct,
        [EnumMember(Value = "redirect")]
        Redirect
    }
}
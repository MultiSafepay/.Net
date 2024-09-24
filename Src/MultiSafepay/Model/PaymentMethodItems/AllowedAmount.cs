using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class AllowedAmount
    {
        [JsonProperty("max")]
        public int? Max { get; set; }

        [JsonProperty("min")]
        public int? Min { get; set; }
    }
}

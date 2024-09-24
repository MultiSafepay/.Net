using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class Apps
    {
        [JsonProperty("fastcheckout")]
        public PaymentMethodItems.App FastCheckout { get; set; }

        [JsonProperty("payment_components")]
        public PaymentMethodItems.App PaymentComponents { get; set; }
    }
}

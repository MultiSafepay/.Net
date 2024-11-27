using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentMethodsItem
    {
        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("card_expiry_date")]
        public string CardExpiryDate { get; set; }

        [JsonProperty("external_transaction_id")]
        public string ExternalTransactionId { get; set; }

        [JsonProperty("payment_description")]
        public string PaymentDescription { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

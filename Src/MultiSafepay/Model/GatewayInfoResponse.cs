using System;
using MultiSafepay.Converter;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class GatewayInfoResponse
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("issuer_name")]
        public string IssuerName { get; set; }

        [JsonProperty("destination_account_id")]
        public dynamic DestinationAccountId { get; set; }
        [JsonProperty("destination_holder_name")]
        public string DestinationHolderName { get; set; }
        [JsonProperty("destination_holder_city")]
        public string DestinationHolderCity { get; set; }
        [JsonProperty("destination_holder_country")]
        public string DestinationHolderCountry { get; set; }
        [JsonProperty("destination_holder_iban")]
        public string DestinationHolderIban { get; set; }
        [JsonProperty("destination_holder_swift")]
        public string DestinationHolderSwift { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }
        [JsonProperty("account_holder_country")]
        public string AccountHolderCountry { get; set; }
    }
}

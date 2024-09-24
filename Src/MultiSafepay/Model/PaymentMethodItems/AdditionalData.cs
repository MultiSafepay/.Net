using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class AdditionalData
    {
        [JsonProperty("issuers")]
        public IList<PaymentMethodItems.Issuer> Issuers { get; set; }
    }
}

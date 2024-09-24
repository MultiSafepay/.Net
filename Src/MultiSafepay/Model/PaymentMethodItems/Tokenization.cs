using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class Tokenization
    {
        [JsonProperty("is_enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("models")]
        public PaymentMethodItems.TokenizationModels Models { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class TokenizationModels
    {
        [JsonProperty("cardonfile")]
        public bool CardOnFile { get; set; }

        [JsonProperty("subscription")]
        public bool Subscription { get; set; }

        [JsonProperty("unscheduled")]
        public bool UnScheduled { get; set; }
    }
}

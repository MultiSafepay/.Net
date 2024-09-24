using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Coupons
    {
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }
       
        [JsonProperty("allow")]
        public List<string> Allow { get; set; }
    }
}

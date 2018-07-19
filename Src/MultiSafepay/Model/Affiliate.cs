using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model
{
    public class Affiliate
    {
        [JsonProperty("split_payments")]
        public IList<SplitPayments> Items { get; set; }
    }
}
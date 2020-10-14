using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model
{
    public class CaptureResult
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}

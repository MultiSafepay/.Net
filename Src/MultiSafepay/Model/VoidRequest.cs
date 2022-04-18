using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model
{
    public class VoidRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

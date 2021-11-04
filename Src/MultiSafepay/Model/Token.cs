using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model
{
    public class TokenData
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("display")]
        public string DisplayCard { get; set; }
        [JsonProperty("bin")]
        public string Bin { get; set; }
        [JsonProperty("expiry_date")]
        public int ExpiryDate { get; set; }
        [JsonProperty("expired")]
        public bool Expired { get; set; }
        [JsonProperty("last4")]
        public string Last4Digits { get; set; }
        [JsonProperty("model")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringModelType RecurringModel { get; set; }
    }
}

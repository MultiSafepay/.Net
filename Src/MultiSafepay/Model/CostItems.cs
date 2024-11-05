﻿using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class CostItems
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("dst")]
        public int Dst { get; set; }
    }
}
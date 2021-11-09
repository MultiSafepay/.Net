using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model
{
    public class TokenDeleteResponse
    {
        [JsonProperty("removed")]
        public bool Removed { get; set; }
    }
}

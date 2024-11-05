using Newtonsoft.Json;

namespace MultiSafepay.Model.Pager
{
    public class Pager
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("cursor")]
        public Cursor Cursor { get; set; }
    }
}

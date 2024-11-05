using Newtonsoft.Json;

namespace MultiSafepay.Model.Pager
{
    public class Cursor
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

    }
}

using Newtonsoft.Json;

namespace MultiSafepay.Model.Transactions
{
    public class TransactionsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Transaction[] Data { get; set; }

        [JsonProperty("pager")]
        public Pager.Pager Pager { get; set; }

    }
}

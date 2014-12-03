using Newtonsoft.Json;

namespace MultiSafepay
{
    public class ResponseMessage
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        [JsonProperty("error_info")]
        public string ErrorInfo { get; set; }
    }

    public class ResponseMessage<T> : ResponseMessage
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}

using Newtonsoft.Json;

namespace MultiSafepay
{
    /// <summary>
    /// Message wrapper for responses from the MultiSafepay API that do not contain any additional data.
    /// </summary>
    public class ResponseMessage
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        [JsonProperty("error_info")]
        public string ErrorInfo { get; set; }
    }

    /// <summary>
    /// Message wrapper for responses from the MultiSafepay API that also included typed data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseMessage<T> : ResponseMessage
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}

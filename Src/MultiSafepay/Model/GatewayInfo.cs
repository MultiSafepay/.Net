using System;
using MultiSafepay.Converter;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class GatewayInfo
    {
        private GatewayInfo()
        {
        }

        [JsonProperty("issuer_id")]
        public string IssuerId { get; set; }
        [JsonProperty("birthday"), JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? Birthday { get; set; }
        [JsonProperty("bank_account")]
		public string BankAccount { get; set; }
        [JsonProperty("phone")]
		public string Phone { get; set; }
        [JsonProperty("referrer")]
		public string Referrer { get; set; }
        [JsonProperty("user_agent")]
		public string UserAgent { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        public static GatewayInfo IDeal(string issuerId)
        {
            return new GatewayInfo
            {
                IssuerId = issuerId
            };
        }
        public static GatewayInfo PayAfterDelivery(DateTime? birthday, string bankAccount, string phone, string email, string referrer, string userAgent)
        {
            return new GatewayInfo
            {
                Birthday = birthday,
                BankAccount = bankAccount,
                Phone = phone,
                Email = email,
                Referrer = referrer,
                UserAgent = userAgent
            };
        }
    }
}

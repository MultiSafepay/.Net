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
        [JsonProperty("qr_size")]
        public int QrSize { get; set; }
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
        [JsonProperty("gender")]
        public string Gender { get; set; }

        public static GatewayInfo IDeal(string issuerId)
        {
            return new GatewayInfo
            {
                IssuerId = issuerId
            };
        }
        public static GatewayInfo IDealQR(int qrSize)
        {
            return new GatewayInfo
            {
                QrSize = qrSize
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

        public static GatewayInfo Einvoice(DateTime? birthday, string bankAccount, string phone, string email, string referrer, string userAgent)
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

        public static GatewayInfo Klarna(DateTime birthday, string gender, string phone, string email)
        {
            return new GatewayInfo
            {
                Birthday = birthday,
                Gender = gender,
                Phone = phone,
                Email = email,
            };
        }
    }
}

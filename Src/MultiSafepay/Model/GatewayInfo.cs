using System;
using MultiSafepay.Converter;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class GatewayInfo
    {
        [JsonProperty("issuer_id")]
        public string IssuerId { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("qr_size")]
        public int QrSize { get; set; }
        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }
        [JsonProperty("account_holder_city")]
        public string AccountHolderCity { get; set; }
        [JsonProperty("account_holder_country")]
        public string AccountHolderCountry { get; set; }
        [JsonProperty("account_holder_iban")]
        public string AccountHolderIban { get; set; }
        [JsonProperty("account_holder_swift")]
        public string AccountHolderSwift { get; set; }
        [JsonProperty("account_holder_bic")]
        public string AccountHolderBic { get; set; }
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
        [JsonProperty("personal_number")]
        public string PersonalNumber { get; set; }
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
        [JsonProperty("card_holder_name")]
        public string CardHolderName { get; set; }
        [JsonProperty("card_expiry_date")]
        public string CardExpiryDate { get; set; }
        [JsonProperty("card_cvc")]
        public string CardCvc { get; set; }
        [JsonProperty("term_url")]
        public string TermUrl { get; set; }
        [JsonProperty("emandate")]
        public string Emandate { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }
        [JsonProperty("coc")]
        public string Coc { get; set; }
        [JsonProperty("vat")]
        public string Vat { get; set; }
        [JsonProperty("collecting_flow")]
        public string CollectingFlow { get; set; }
        [JsonProperty("action_on_declined")]
        public string ActionOnDeclined { get; set; }
        [JsonProperty("company_type")]
        public string CompanyType { get; set; }

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

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GatewayInfoTests
    {
        [TestMethod]
        public void GatewayInfo_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var gatewayInfo = GatewayInfo.PayAfterDelivery(null, null, null, null, null, null);

            // Act
            var serializedObject = JsonConvert.SerializeObject(gatewayInfo);

            // Assert
            Assert.AreEqual(@"{
                ""issuer_id"": null,
                ""account_id"": null,
                ""qr_size"": 0,
                ""account_holder_name"": null,
                ""account_holder_city"": null,
                ""account_holder_country"": null,
                ""account_holder_iban"": null,
                ""account_holder_swift"": null,
                ""account_holder_bic"": null,
                ""birthday"": null,
                ""bank_account"": null,
                ""phone"": null,
                ""referrer"": null,
                ""user_agent"": null,
                ""email"": null,
                ""gender"": null,
                ""personal_number"": null,
                ""card_number"": null,
                ""card_holder_name"": null,
                ""card_expiry_date"": null,
                ""card_cvc"": null,
                ""term_url"": null,
                ""emandate"": null,
                ""company"": null,
                ""po_number"": null,
                ""coc"": null,
                ""vat"": null,
                ""collecting_flow"": null,
                ""action_on_declined"": null,
                ""company_type"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

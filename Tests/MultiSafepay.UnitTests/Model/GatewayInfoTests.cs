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
                ""qr_size"": 0,
		        ""birthday"": null,
		        ""bank_account"": null,
		        ""phone"": null,
		        ""referrer"": null,
		        ""user_agent"": null,
                ""email"": null,
                ""gender"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    public class GatewayInfoTests
    {
        [TestMethod]
        public void GatewayInfo_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var gatewayInfo = new GatewayInfo();

            // Act
            var serializedObject = JsonConvert.SerializeObject(gatewayInfo);

            // Assert
            Assert.AreEqual(@"{
                ""issuer_id"": null,
		        ""birthday"": null,
		        ""bank_account"": null,
		        ""phone"": null,
		        ""referrer"": null,
		        ""user_agent"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

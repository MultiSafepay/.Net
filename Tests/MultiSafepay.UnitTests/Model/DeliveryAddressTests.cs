using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DeliveryAddressTests
    {
        [TestMethod]
        public void DeliveryAddress_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var deliveryAddress = new DeliveryAddress();

            // Act
            var serializedObject = JsonConvert.SerializeObject(deliveryAddress);

            // Assert
            Assert.AreEqual(@"{
		        ""first_name"": null,
		        ""last_name"": null,
		        ""address1"": null,
		        ""address2"": null,
		        ""house_number"": null,
		        ""zip_code"": null,
		        ""city"": null,
		        ""state"": null,
		        ""country"": null,
		        ""phone"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShippingMethodsTests
    {
        [TestMethod]
        public void ShippingMethods_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shippingMethods = new ShippingMethods();

            // Act
            var serializedObject = JsonConvert.SerializeObject(shippingMethods);

            // Assert
            Assert.AreEqual(@"{
				""flat_rate_shipping"": null,
				""pickup"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

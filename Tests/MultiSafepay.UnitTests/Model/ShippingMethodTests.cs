using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShippingMethodTests
    {
        [TestMethod]
        public void ShippingMethod_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shippingMethod = new ShippingMethod(null, 0, null);

            // Act
            var serializedObject = JsonConvert.SerializeObject(shippingMethod);

            // Assert
            Assert.AreEqual(@"{
				""name"": null,
				""price"": 0.0,
				""currency"": null,
				""allowed_areas"": null,
				""excluded_areas"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

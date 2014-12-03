using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShippingStatusTests
    {
        [TestMethod]
        public void ShippingStatus_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shippingStatus = new ShippingStatus();

            // Act
            var serializedObject = JsonConvert.SerializeObject(shippingStatus);

            // Assert
            Assert.AreEqual(@"{
	            ""tracktrace_code"": null,  
	            ""carrier"": null,
	            ""ship_date"": null,
	            ""memo"": null
            }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RefundTests
    {
        [TestMethod]
        public void Refund_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var refund = new Refund();

            // Act
            var serializedObject = JsonConvert.SerializeObject(refund);

            // Assert
            Assert.AreEqual(@"{
	            ""type"": ""refund"",
	            ""amount"": 0,
	            ""currency"": null,
	            ""description"": null
            }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PaymentLinkTests
    {
        [TestMethod]
        public void PaymentLink_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var paymentLink = new PaymentLink();

            // Act
            var serializedObject = JsonConvert.SerializeObject(paymentLink);

            // Assert
            Assert.AreEqual(@"{
                ""order_id"":null,
                ""payment_url"":null,
                ""qr_url"":null,
                ""custom_info"":null
                }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

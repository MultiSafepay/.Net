using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.PaymentMethods
{
    [TestClass]
    public class GetPaymentMethod
    {
        [TestMethod]
        public void PaymentMethods_GetPaymentMethod()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url, null, false);

            // Act
            var method = client.GetPaymentMethod("VISA");

            // Assert
            Assert.AreEqual("VISA", method.Id);
        }
    }
}

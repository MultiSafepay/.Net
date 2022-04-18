using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Transactions
{
    [TestClass]
    public class Transactions
    {
        [TestMethod]
        public void Transactions_CreateARefund()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.CreateRefund("546dd9aeb49aa", 100, "EUR", "This is a refund");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.TransactionId));
        }

        [TestMethod]
        public void Transactions_CaptureOrder()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.CaptureOrder("62756f57-f24d-403e-b6ed-3c53961dc801", 500, null, "Order Shipped");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.TransactionId);
        }

        [TestMethod]
        public void Transactions_VoidOrder()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.VoidOrder("62756f57-f24d-403e-b6ed-3c53961dc801", "Order Canceled");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }
    }
}

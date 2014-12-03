using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Transactions
{
    [TestClass]
    public class Transactions
    {
        [TestMethod]
        public void Transactions_RetrieveTransaction()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            string transactionId = "2242232";
            var result = client.GetTransaction(transactionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(transactionId, result.Id);
            Assert.Fail();
            // <TODO> need to check that all data is being deserialized after message format change
        }

        [TestMethod]
        public void Transactions_CreateARefund()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.CreateRefund("4f5b7db0-189a-4767-9a80-2c2fac455743", 500, "EUR", "This is a refund");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.TransactionId));
        }
    }
}

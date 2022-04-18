using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class Tokens
    {
        [TestMethod]
        public void Tokens_GetCustomerTokens()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.GetCustomerTokens("test1");

            // Assert
            Assert.IsNotNull(result.Tokens);
            Assert.IsTrue(result.Tokens.Length > 0);
        }
    }
}

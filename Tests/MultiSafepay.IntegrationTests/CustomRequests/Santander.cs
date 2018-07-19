using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using System.Configuration;

namespace MultiSafepay.IntegrationTests.CustomRequests
{
    [TestClass]
    public class Santader
    {
        private static MultiSafepayClient Client { get; set; }
        private void setClient()
        {
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            Client = new MultiSafepayClient(apiKey, url);
        }

        [TestMethod]
        public void CustomRequests_Santader_Redirect()
        {
            this.setClient();
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                Type = OrderType.Redirect,
                OrderId = orderId,
                GatewayId = "SANTANDER",
                AmountInCents = 1066,
                CurrencyCode = "EUR",
                Description = ".Net wrapper test",
                PaymentOptions = new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                Customer = new Customer()
                {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Country = "NL",
                    Locale = "EN",
                    Email = "test@multisafepay.com"
                }
            };

            // Act
            var result = Client.CustomOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void CustomRequests_Santader_Direct()
        {
            this.setClient();
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                Type = OrderType.Direct,
                OrderId = orderId,
                GatewayId = "SANTANDER",
                AmountInCents = 28000,
                CurrencyCode = "EUR",
                Description = ".Net wrapper test",
                PaymentOptions = new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                Customer = new Customer()
                {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Country = "NL",
                    Locale = "EN"
                }
            };

            // Act
            var result = Client.CustomOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }
    }
}
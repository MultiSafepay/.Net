using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using System.Configuration;

namespace MultiSafepay.IntegrationTests.CustomRequests
{
    [TestClass]
    public class Ideal
    {
        private static MultiSafepayClient Client { get; set; }
        private void setClient()
        {
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            Client = new MultiSafepayClient(apiKey, url);  
        }
       
        [TestMethod]
        public void CustomRequests_Ideal_Redirect()
        {
            this.setClient();
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                Type = OrderType.Redirect,
                OrderId = orderId,
                GatewayId = "IDEAL",
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
        public void CustomRequests_Ideal_Direct()
        {
            this.setClient();
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                Type = OrderType.Direct,
                OrderId = orderId,
                GatewayId = "IDEAL",
                AmountInCents = 1066,
                CurrencyCode = "EUR",
                Description = ".Net wrapper test",
                PaymentOptions = new PaymentOptions {
                    NotificationUrl = "http://example.com/notify", 
                    SuccessRedirectUrl = "http://example.com/success", 
                    CancelRedirectUrl = "http://example.com/failed"
                },
                GatewayInfo = new GatewayInfo
                {
                    IssuerId = "3151"
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

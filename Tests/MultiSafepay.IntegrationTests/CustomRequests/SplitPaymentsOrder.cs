using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.CustomRequests
{
    [TestClass]
    public class SplitPaymentsOrder
    {
        private static MultiSafepayClient Client { get; set; }
        private void setClient()
        {
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            Client = new MultiSafepayClient(apiKey, url);
        }

        [TestMethod]
        public void CustomRequests_SplitPaymentsOrder_Order()
        {
            this.setClient();

            var order = new Order
            {
                Type = OrderType.Redirect,
                OrderId = Guid.NewGuid().ToString(),
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
                },
                Affiliate = new Affiliate()
                {
                    Items = new[]
                    {
                        new SplitPayments() {
                            merchant = 123456,
                            @fixed = 116,
                            description = "Fixed fee"

                        },
                        new SplitPayments(){
                            merchant = 123456,
                            percentage = 11,
                            description = "Percentage fee"
                        }
                    }
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

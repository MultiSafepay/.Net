using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class PayAfterDeliveryOrderRedirect
    {
        [TestMethod]
        public void Orders_PayAfterDeliveryOrderRedirect()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateRedirectPayAfterDeliveryOrder(orderId, "product description", 24200, "EUR",
              new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
              GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
              new ShoppingCart
              {
                  Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 200.0, 1, "EUR")
                    }
              },
              new CheckoutOptions()
              {
                  TaxTables = new TaxTables()
                  {
                      DefaultTaxTable = new TaxTable()
                      {
                          Name = "Default",
                          Rules = new[] { new TaxRateRule() { Rate = 0.21 } },
                          ShippingTaxed = false
                      }
                  }
              },
              new Customer()
              {
                  FirstName = "John",
                  LastName = "Doe",
                  HouseNumber = "39",
                  Address1 = "Kraanspoor",
                  City = "Amsterdam",
                  Country = "NL",
                  PostCode = "1033SC"
              }
              );

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }
    }
}

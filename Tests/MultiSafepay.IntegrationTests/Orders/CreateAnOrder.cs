using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class CreateAnOrder
    {
        [TestMethod]
        public void Orders_CreateAnOrder_iDEAL()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            var orderRequest = new OrderRequest(PaymentFlow.Redirect, "testorderid", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert

        }
    }
}

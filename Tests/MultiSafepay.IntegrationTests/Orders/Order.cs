using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class Order
    {
        [TestMethod]
        public void Orders_CreateOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            
            var orderRequest = OrderRequest.CreateRedirect(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));
            
            orderRequest.Customer = new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "Kraanspoor 39",
                City = "Amsterdam",
                Country = "Netherlands",
                ZipCode = "1033SC"
            };

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateOrder_StoreCustomVariables()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateRedirect(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success",
                    "http://example.com/failed"));

            orderRequest.Var1 = "custom 1";
            orderRequest.Var2 = "custom 2";
            orderRequest.Var3 = "custom 3";

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));

            // Act
            OrderResponse retrievedOrder;
            // <TODO> remove this hack once the api is returning the order the first time
            try
            {
                retrievedOrder = client.GetOrder(orderId);
            }
            catch
            {
                retrievedOrder = client.GetOrder(orderId);
            }
             

            // Assert
            Assert.IsNotNull(retrievedOrder);
            Assert.AreEqual(orderRequest.Var1, retrievedOrder.TransactionDetails.Var1);
            Assert.AreEqual(orderRequest.Var2, retrievedOrder.TransactionDetails.Var2);
            Assert.AreEqual(orderRequest.Var3, retrievedOrder.TransactionDetails.Var3);

        }

        [TestMethod]
        public void Order_SetOrderInvoiceId()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.SetOrderInvoiceId("4f5b7db0-189a-4767-9a80-2c2fac455743", "testinvoiceid47843979438276493287");

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}

﻿using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class DirectOrder
    {
        [TestMethod]
        public void Orders_CreateDirectOrder_IDEAL()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var orderRequest = OrderRequest.CreateDirectIdeal("3151", orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));

        }

        [TestMethod]
        public void Orders_CreateDirectOrder_IDEALQR()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var orderRequest = OrderRequest.CreateDirectIdealQR(300, orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.QrUrl));

        }

        [TestMethod]
        public void Orders_CreateDirectOrder_IDEALQRGatewayInfo()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var gatewayInfo = new GatewayInfo();
            gatewayInfo.QrSize = 300;
            gatewayInfo.MaxAmount = 1000;
            gatewayInfo.MinAmount = 100;
            var orderRequest = OrderRequest.CreateDirectIdealQR(gatewayInfo, orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.QrUrl));

        }

        [TestMethod]
        public void Orders_CreateDirectOrder_BankTransfer()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var orderRequest = OrderRequest.CreateDirectBankTransfer(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
        }

        [TestMethod]
        public void Orders_CreateOrder_StoreCustomVariables()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateDirectIdeal("3151", orderId, "product description", 1000, "EUR",
                 new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

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
            OrderResponse retrievedOrder = client.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(retrievedOrder);
            Assert.AreEqual(orderRequest.Var1, retrievedOrder.Var1);
            Assert.AreEqual(orderRequest.Var2, retrievedOrder.Var2);
            Assert.AreEqual(orderRequest.Var3, retrievedOrder.Var3);
        }

        [TestMethod]
        public void Orders_CreateOrder_TemporaryVariables()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateDirectIdeal("3151", orderId, "product description", 1000, "EUR",
                 new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            orderRequest.Var1 = "custom 1";
            orderRequest.Var2 = "custom 2";
            orderRequest.Var3 = "custom 3";

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
        }

        [TestMethod]
        public void Orders_CreateDirectOrder_FromRecurringId()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var orderRequest = OrderRequest.CreateRecurring("token", orderId, "product description", 500, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            orderRequest.Customer = new Customer()
            {
                Reference = "test1"
            };

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            //Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }
    }
}

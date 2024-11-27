using System;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Transactions
{
    [TestClass]
    public class Transactions
    {
        [TestMethod]
        public void Transactions_GetTransaction()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url, null, true);

            // Act
            var trx = client.GetTransaction("1730211315130149");

            // Assert
            Assert.IsNotNull(trx);
            Assert.IsFalse(String.IsNullOrEmpty(trx.TransactionId));
        }

        [TestMethod]
        public void Transactions_List()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url, null, true);

            // Act
            var filter = new Model.Transactions.TransactionsFilter();
            filter.Limit = 10;
            //Filter examples

            //filter.SideId = 123;
            //filter.After = "ZARnIQXqdAQArcSS";
            //filter.CompletedUntil = DateTime.Now;
            //filter.CompletedUntil = new DateTime(2024, 11, 4);

            //filter.DebitCredit = Model.Transactions.DebitCreditTypes.CREDIT;
            /*
            filter.FinancialStatus = new System.Collections.Generic.List<Model.Transactions.FinancialStatusEnum> {
                Model.Transactions.FinancialStatusEnum.completed,
                Model.Transactions.FinancialStatusEnum.initialized
            };
            */

            /*
            filter.Status = new System.Collections.Generic.List<Model.Transactions.StatusEnum> {
                Model.Transactions.StatusEnum.completed,
                Model.Transactions.StatusEnum.initialized
            };
            */

            var result = client.GetTransactions(filter);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            //Assert.AreEqual("completed", result.Data[0].FinancialStatus);
            Assert.IsNotNull(result.Pager.Cursor.After);
            Assert.IsNotNull(result.Data[0]);
        }

        [TestMethod]
        public void Transactions_CreateARefund()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.CreateRefund("order_459228", 100, "EUR", "This is a refund");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.TransactionId));
            Assert.IsFalse(String.IsNullOrEmpty(result.RefundId));
        }

        [TestMethod]
        public void Transactions_UpdateARefund()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url, null, true);

            // Act
            var result = client.UpdateRefund(
                "order_459228", 
                "1730989257101838", 
                new UpdateOrder() {
                    Status = Model.Transactions.StatusEnum.completed.ToString(),
                    Description = "Refund update"
                });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.TransactionId));
            Assert.IsFalse(String.IsNullOrEmpty(result.RefundId));
        }

        [TestMethod]
        public void Transactions_OrderUpdate()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url, null, true);

            // Act
            var result = client.OrderUpdate(
                "apitool_459228",
                new UpdateOrder()
                {
                    Status = Model.Transactions.StatusEnum.@void.ToString(),
                    //ExcludeOrder = false,
                    //TrackingCode = "XXXXX",
                    Memo = "Test update"
                });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
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

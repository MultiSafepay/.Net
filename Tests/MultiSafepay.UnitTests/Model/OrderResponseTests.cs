using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class OrderResponseTests
    {
        [TestMethod]
        public void Order_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var order = new OrderResponse();

            // Act
            var serializedObject = JsonConvert.SerializeObject(order);

            // Assert
            Assert.AreEqual(@"{
            ""transaction_id"":null,
            ""created"":null,
            ""id"":null,
            ""currency"":null,
            ""amount"":0,
            ""gateway"":0,
            ""description"":null,
            ""var1"":null,
            ""var2"":null,
            ""var3"":null,
            ""items"":null,
            ""customer"":null,
            ""customer_delivery"":null,
            ""payment_details"":null
            }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

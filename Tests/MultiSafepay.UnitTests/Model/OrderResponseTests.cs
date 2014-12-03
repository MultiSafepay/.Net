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
                ""ewallet"":null,
                ""customer"":null,
                ""customer_delivery"":null,
                ""transaction"":null,
                ""payment_details"":null
                }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    public class NotificationUrlTests
    {
        [TestMethod]
        public void NotificationUrl_ParseOrderId_HasOrderIdQueryParam()
        {
            // Arrange 
            var url = "https://www.samplestore.com/notifications?transactionid=1434046577&timestamp=1434014648";

            // Act
            var orderId = NotificationUrl.ParseOrderId(url);

            // Assert
            Assert.AreEqual("1434046577", orderId);
        }

        [TestMethod]
        public void NotificationUrl_ParseOrderId_MissingOrderIdQueryParam()
        {
            // Arrange 
            var url = "https://www.samplestore.com/notifications";

            // Act
            var orderId = NotificationUrl.ParseOrderId(url);

            // Assert
            Assert.IsNull(orderId);
        }

        [TestMethod]
        public void NotificationUrl_ParseOrderId_EmptyOrderIdQueryParam()
        {
            // Arrange 
            var url = "https://www.samplestore.com/notifications?transactionid=&timestamp=1434014648";

            // Act
            var orderId = NotificationUrl.ParseOrderId(url);

            // Assert
            Assert.IsNull(orderId);
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PaymentOptionsTests
    {
        [TestMethod]
        public void PaymentOptions_CloseWindow_DefaultsToTrue()
        {
            // Act
            var paymentOptions = new PaymentOptions();

            // Assert
            Assert.IsTrue(paymentOptions.CloseWindow);
        }

        [TestMethod]
        public void PaymentOptions_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var paymentOptions = new PaymentOptions();

            // Act
            var serializedObject = JsonConvert.SerializeObject(paymentOptions);

            // Assert
            Assert.AreEqual(@"{
		                    ""notification_url"": null,
		                    ""redirect_url"":null,
		                    ""cancel_url"":null,
		                    ""close_window"":true
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

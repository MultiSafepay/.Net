using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PaymentDetailsTests
    {
        [TestMethod]
        public void PaymentLink_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var paymentDetails = new PaymentDetails();

            // Act
            var serializedObject = JsonConvert.SerializeObject(paymentDetails);

            // Assert
            Assert.AreEqual(@"{
                ""type"":null,
                ""recurring_id"": null,
                ""account_id"":null,
                ""account_holder_name"":null,
                ""external_transaction_id"":null,
                ""last4"":null,
                ""account_iban"":null,
                ""account_bic"":null
                }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

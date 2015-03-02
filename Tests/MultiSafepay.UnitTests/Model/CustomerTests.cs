using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var customer = new Customer();

            // Act
            var serializedObject = JsonConvert.SerializeObject(customer);

            // Assert
            Assert.AreEqual(@"{
                                ""company"": false,
		                        ""locale"": null,
		                        ""ip_address"": null,
		                        ""forwarded_ip"": null,
		                        ""first_name"": null,
		                        ""last_name"": null,
		                        ""address1"": null,
		                        ""address2"": null,
		                        ""house_number"": null,
		                        ""zip_code"": null,
		                        ""city"": null,
		                        ""state"": null,
		                        ""country"": null,
		                        ""phone"": null,
		                        ""email"": null,
                                ""disable_send_email"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

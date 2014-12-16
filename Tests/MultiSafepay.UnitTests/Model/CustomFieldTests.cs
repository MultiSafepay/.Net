using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CustomFieldTests
    {
        [TestMethod]
        public void CustomField_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var customField = new CustomField(null, CustomFieldType.textbox);

            // Act
            var serializedObject = JsonConvert.SerializeObject(customField);

            // Assert
            Assert.AreEqual(@"{
				""standard_type"": null,
				""name"": null,
                ""type"": ""textbox"",
                ""save_value"": false,
                ""default"": null,
                ""description_top"": null,
                ""description_right"": null,
                ""description_bottom"": null,
                ""area_restrictions"": null,
                ""label"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    public class FieldDescriptionTests
    {
        [TestMethod]
        public void FieldDescription_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var fieldDescription = new FieldDescription();

            // Act
            var serializedObject = JsonConvert.SerializeObject(fieldDescription);

            // Assert
            Assert.AreEqual(@"{
				""value"": null,
				""style"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

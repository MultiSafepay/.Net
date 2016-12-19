using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TaxTableTests
    {
        [TestMethod]
        public void TaxTable_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var taxTable = new TaxTable();

            // Act
            var serializedObject = JsonConvert.SerializeObject(taxTable);

            // Assert
            Assert.AreEqual(@"{
				""name"": null,
                ""shipping_taxed"": false,
                ""rules"": null,
				""standalone"": false
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}

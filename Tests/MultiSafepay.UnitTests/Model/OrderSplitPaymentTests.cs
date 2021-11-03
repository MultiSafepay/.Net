using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class OrderSplitPaymentTests
    {
        [TestMethod]
        public void Order_CheckSplitPayments_SetsRequiredProperties()
        {
            var order = new Order
            {
                Type = OrderType.Redirect,
                OrderId = Guid.NewGuid().ToString(),
                GatewayId = "IDEAL",
                AmountInCents = 1066,
                CurrencyCode = "EUR",
                Description = ".Net wrapper test",
                PaymentOptions = new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                Customer = new Customer()
                {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Country = "NL",
                    Locale = "EN",
                    Email = "test@multisafepay.com"
                },
                Affiliate = new Affiliate()
                {
                    Items = new[]
                    {
                        new SplitPayments(){ 
                            merchant = 123456,
                            @fixed = 112,
                            description = "Fixed fee"

                        },
                        new SplitPayments(){
                            merchant = 123456,
                            percentage = 10,
                            description = "Percentage fee"
                        }
                    } 
                }
            };
            
            Assert.AreEqual(null, order.Affiliate.Items[0].percentage);
            Assert.AreEqual(null, order.Affiliate.Items[1].@fixed);
        }
    }
}

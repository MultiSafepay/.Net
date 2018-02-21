using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class RedirectOrder
    {
        [TestMethod]
        public void Orders_CreateRedirect()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();
            var orderRequest = OrderRequest.CreateRedirect(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateRedirectWithTemplate()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            //Template Id provided in MSP merchants panel
            var templateId = "template-id";

            var orderRequest = OrderRequest.CreateRedirectWithTemplate(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                templateId,
                new Template()
                {
                    Version = "1.0",//Required
                    Header = new TemplateHeader()
                    {
                        Background = "#dedede",
                        Text = "#333333",
                        Logo = new TemplateHeaderObject()
                        {
                            Image = "https://via.placeholder.com/150x150"
                        }
                    },
                    Body = new TemplateBody()
                    {
                        Text = "#333333",
                        Background = "#cccccc",
                        Link = new TemplateButtonObject()
                        {
                            Text = "#00acf1"
                        }
                    },
                    Container = new TemplateContainer()
                    {
                        Text = "#626161",
                        Label = "#a4a3a3",
                        Background = "#ffffff"
                    },
                    Cart = new TemplateCart()
                    {
                        Text = "#333333",
                        Label = "#8b8b8b",
                        Background = "#ffffff",
                        Border = "#d7d7d7"
                    },
                    PaymentForm = new TemplatePaymentForm()
                    {
                        Background = "#ffffff",
                        Border = "#d7d7d7",
                        Inputs = new TemplateInputObject()
                        {
                            Border = "#d7d7d7",
                            Label = "#38839e"
                        }
                    },
                    Buttons = new TemplateButtons()
                    {
                        PaymentMethod = new TemplateButtonObject()
                        {
                            Background = "#ffffff",
                            Text = "#38839e",
                            Border = "#d7d7d7",
                            Hover = new TemplateButtonObjectState()
                            {
                                Background = "#cccccc"
                            }
                        },
                        Primary = new TemplateButtonObject()
                        {
                            Background = "#cc0000",
                            Text = "#ffffff"
                        },
                        Secondary = new TemplateButtonObject()
                        {
                            Background = "#38839e",
                            Text = "#ffffff"
                        }
                    }
                });

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }
    }
}

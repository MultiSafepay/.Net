<p align="center">
  <img src="https://www.multisafepay.com/img/multisafepaylogo.svg" width="400px" position="center">
</p>

# .Net wrapper for the MultiSafepay API #
This wrapper simplifies working with the MultiSafepay API and allows you to integrate MultiSafepay within your .Net application.

## About MultiSafepay ##
MultiSafepay is a collecting payment service provider which means we take care of the agreements, technical details and payment collection required for each payment method. You can start selling online today and manage all your transactions from one place.

## Requirements
- To use the wrapper you need a MultiSafepay account. You can create a test account on https://testmerchant.multisafepay.com/signup

## Installation
- Clone this git repository.
- Also available on NuGet. https://www.nuget.org/packages/MultiSafepay/

```
Install-Package MultiSafepay
```

## Usage
Setup the client for testing
```
var client = new MultiSafepayClient("API_KEY", "https://testapi.multisafepay.com/v1/json/");
```
Get list of payment methods
```
var gateways = client.GetGateways(null, "EUR");
```
Creating a test order
```
var client = new MultiSafepayClient("API_KEY", "https://testapi.multisafepay.com/v1/json/");
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
                }
            };

var result = client.CustomOrder(order);
```
Click [here](https://github.com/MultiSafepay/.Net/tree/master/Tests/MultiSafepay.IntegrationTests) for more examples.

## Support
If you have any issues, problems or questions you can create an issue on this repository or contact us at <a href="mailto:techsupport@multisafepay.com">techsupport@multisafepay.com</a>

## Mistakes and improvements 
If you spot mistakes or want to contribute in improving this wrapper, feel free to [create pull requests](https://github.com/MultiSafepay/.Net/pulls)

## API Documentation
[Click here](https://docs.multisafepay.com/api/) for the MultiSafepay API documentation.

## License
[MIT License](https://github.com/MultiSafepay/.Net/blob/master/LICENSE)
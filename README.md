<p align="center">
    <img src="https://camo.githubusercontent.com/517483ae0eaba9884f397e9af1c4adc7bbc231575ac66cc54292e00400edcd10/68747470733a2f2f7777772e6d756c7469736166657061792e636f6d2f66696c6561646d696e2f74656d706c6174652f696d672f6d756c7469736166657061792d6c6f676f2d69636f6e2e737667" width="400px" position="center">
</p>

# .Net wrapper for the MultiSafepay API
This wrapper simplifies working with the MultiSafepay API and lets you integrate MultiSafepay in your .Net application.

## About MultiSafepay
MultiSafepay is a Dutch payment service provider, which takes care of contracts, processing transations, and collecting payment for a range of local and international payment methods. Start selling online today and manage all your transactions in one place!

## Requirements
You will need a MultiSafepay account. Consider [creating a test account](https://testmerchant.multisafepay.com/signup) first. 

## Installation
Clone this git repository. (Also available on [NuGet](https://www.nuget.org/packages/MultiSafepay/)).

```
Install-Package MultiSafepay
```

## Usage
Set up the client for testing:
```csharp
var client = new MultiSafepayClient("API_KEY", "https://testapi.multisafepay.com/v1/json/");
```
Get a list of payment methods:
```csharp
var gateways = client.GetGateways(null, "EUR");
```
Create a test order:
```csharp
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
See [more examples](https://github.com/MultiSafepay/.Net/tree/master/Tests/MultiSafepay.IntegrationTests).

## Support
Create an issue on this repository or email <a href="mailto:integration@multisafepay.com">integration@multisafepay.com</a>

## Contributions 
Feel free to [create pull requests](https://github.com/MultiSafepay/.Net/pulls) on this repository to suggest improvements.

## API reference
See MultiSafepay Docs – [API reference](https://docs.multisafepay.com/api/).

## License
[MIT License](https://github.com/MultiSafepay/.Net/blob/master/LICENSE)

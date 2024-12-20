# LoggedIn
(*Payments.LoggedIn*)

## Overview

### Available Operations

* [Initialize](#initialize) - Initialize a Bolt payment for logged in shoppers
* [PerformAction](#performaction) - Finalize a pending payment

## Initialize

Initialize a Bolt logged-in shopper's intent to pay for a cart, using the specified payment method. Payments must be finalized before indicating the payment result to the shopper. Some payment methods will finalize automatically after initialization. For these payments, they will transition directly to "finalized" and the response from Initialize Payment will contain a finalized payment.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Payments.LoggedIn.InitializeAsync(
    xPublishableKey: "<value>",
    paymentInitializeRequest: new PaymentInitializeRequest() {
        Cart = new Cart() {
            OrderReference = "order_100",
            OrderDescription = "Order #1234567890",
            DisplayId = "215614191",
            Shipments = new List<CartShipment>() {
                new CartShipment() {
                    Address = AddressReferenceInput.CreateAddressReferenceId(
                        new AddressReferenceId() {
                            DotTag = Boltpay.SDK.Models.Components.AddressReferenceIdTag.Id,
                            Id = "D4g3h5tBuVYK9",
                        }
                    ),
                    Cost = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    Carrier = "FedEx",
                },
            },
            Discounts = new List<CartDiscount>() {
                new CartDiscount() {
                    Amount = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    Code = "SUMMER10DISCOUNT",
                    DetailsUrl = "https://www.example.com/SUMMER-SALE",
                },
            },
            Items = new List<CartItem>() {
                new CartItem() {
                    Name = "Bolt Swag Bag",
                    Reference = "item_100",
                    Description = "Large tote with Bolt logo.",
                    TotalAmount = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    UnitPrice = 1000,
                    Quantity = 1,
                    ImageUrl = "https://www.example.com/products/123456/images/1.png",
                },
            },
            Total = new Amount() {
                Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                Units = 900,
            },
            Tax = new Amount() {
                Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                Units = 900,
            },
        },
        PaymentMethod = PaymentMethodExtended.CreatePaymentMethodReference(
            new PaymentMethodReference() {
                DotTag = Boltpay.SDK.Models.Components.PaymentMethodReferenceTag.Id,
                Id = "X5h6j8uLpVGK",
            }
        ),
    },
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |
| `PaymentInitializeRequest`                                                                                                                                                                                                                                                                                           | [PaymentInitializeRequest](../../Models/Components/PaymentInitializeRequest.md)                                                                                                                                                                                                                                      | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |

### Response

**[PaymentsInitializeResponse](../../Models/Requests/PaymentsInitializeResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Boltpay.SDK.Models.Errors.Error           | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.FieldError      | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.CartError       | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.CreditCardError | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.SDKException    | 5XX                                       | \*/\*                                     |

## PerformAction

Finalize a pending payment being made by a Bolt logged-in shopper. Upon receipt of a finalized payment result, payment success should be communicated to the shopper.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Payments.LoggedIn.PerformActionAsync(
    xPublishableKey: "<value>",
    id: "iKv7t5bgt1gg",
    paymentActionRequest: new PaymentActionRequest() {
        DotTag = Boltpay.SDK.Models.Components.PaymentActionRequestTag.Finalize,
        RedirectResult = "eyJ0cmFuc",
    },
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          | Example                                                                                                                                                                                                                                                                                                              |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                      |
| `Id`                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The ID of the payment to operate on                                                                                                                                                                                                                                                                                  | iKv7t5bgt1gg                                                                                                                                                                                                                                                                                                         |
| `PaymentActionRequest`                                                                                                                                                                                                                                                                                               | [PaymentActionRequest](../../Models/Components/PaymentActionRequest.md)                                                                                                                                                                                                                                              | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |                                                                                                                                                                                                                                                                                                                      |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                                                                                                                      |

### Response

**[PaymentsActionResponse](../../Models/Requests/PaymentsActionResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |
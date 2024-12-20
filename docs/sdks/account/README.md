# Account
(*Account*)

## Overview

Use the Accounts API to access shoppers' accounts to empower your checkout and facilitate shoppers' choices.

### Available Operations

* [GetDetails](#getdetails) - Retrieve account details
* [AddAddress](#addaddress) - Add an address
* [UpdateAddress](#updateaddress) - Edit an existing address
* [DeleteAddress](#deleteaddress) - Delete an existing address
* [AddPaymentMethod](#addpaymentmethod) - Add a payment method
* [DeletePaymentMethod](#deletepaymentmethod) - Delete an existing payment method

## GetDetails

Retrieve a shopper's account details, such as addresses and payment information. The account's details are filtered to be relevant to your merchant account, and some fields may be missing for some accounts. See the schema for details.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.GetDetailsAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |

### Response

**[AccountGetResponse](../../Models/Requests/AccountGetResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |

## AddAddress

Add an address to the shopper's account

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.AddAddressAsync(
    xPublishableKey: "<value>",
    addressListing: new AddressListingInput() {
        FirstName = "Alice",
        LastName = "Baker",
        Company = "ACME Corporation",
        StreetAddress1 = "535 Mission St, Ste 1401",
        StreetAddress2 = "c/o Shipping Department",
        Locality = "San Francisco",
        PostalCode = "94105",
        Region = "CA",
        CountryCode = Boltpay.SDK.Models.Components.CountryCode.Us,
        Email = "alice@example.com",
        Phone = "+14155550199",
    },
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |
| `AddressListing`                                                                                                                                                                                                                                                                                                     | [AddressListingInput](../../Models/Components/AddressListingInput.md)                                                                                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |

### Response

**[AccountAddressCreateResponse](../../Models/Requests/AccountAddressCreateResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |

## UpdateAddress

Edit an existing address on the shopper's account. This does not edit addresses that are already associated with other resources, such as transactions or shipments.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.UpdateAddressAsync(
    xPublishableKey: "<value>",
    id: "D4g3h5tBuVYK9",
    addressListing: new AddressListingInput() {
        FirstName = "Alice",
        LastName = "Baker",
        Company = "ACME Corporation",
        StreetAddress1 = "535 Mission St, Ste 1401",
        StreetAddress2 = "c/o Shipping Department",
        Locality = "San Francisco",
        PostalCode = "94105",
        Region = "CA",
        CountryCode = Boltpay.SDK.Models.Components.CountryCode.Us,
        Email = "alice@example.com",
        Phone = "+14155550199",
    },
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          | Example                                                                                                                                                                                                                                                                                                              |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                      |
| `Id`                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The ID of the address to edit                                                                                                                                                                                                                                                                                        | D4g3h5tBuVYK9                                                                                                                                                                                                                                                                                                        |
| `AddressListing`                                                                                                                                                                                                                                                                                                     | [AddressListingInput](../../Models/Components/AddressListingInput.md)                                                                                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |                                                                                                                                                                                                                                                                                                                      |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                                                                                                                      |

### Response

**[AccountAddressEditResponse](../../Models/Requests/AccountAddressEditResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |

## DeleteAddress

Delete an existing address. Deleting an address does not invalidate or remove the address from transactions or shipments that are associated with it.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.DeleteAddressAsync(
    xPublishableKey: "<value>",
    id: "D4g3h5tBuVYK9",
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          | Example                                                                                                                                                                                                                                                                                                              |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                      |
| `Id`                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The ID of the address to delete                                                                                                                                                                                                                                                                                      | D4g3h5tBuVYK9                                                                                                                                                                                                                                                                                                        |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                                                                                                                      |

### Response

**[AccountAddressDeleteResponse](../../Models/Requests/AccountAddressDeleteResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |

## AddPaymentMethod

Add a payment method to a shopper's Bolt Account Wallet. For security purposes, this request must come from your backend. <br/> **Note**: Before using this API, the credit card details must be tokenized by Bolt's credit card tokenization service. Please review our [Bolt Payment Field Component](https://help.bolt.com/products/ignite/api-implementation/#enhance-payments) or [Install the Bolt Tokenizer](https://help.bolt.com/developers/references/bolt-tokenizer) documentation.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.AddPaymentMethodAsync(
    xPublishableKey: "<value>",
    paymentMethod: PaymentMethodInput.CreatePaymentMethodAffirm(
        new PaymentMethodAffirm() {
            DotTag = Boltpay.SDK.Models.Components.PaymentMethodAffirmTag.Affirm,
            ReturnUrl = "www.example.com/handle_affirm_success",
        }
    ),
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |
| `PaymentMethod`                                                                                                                                                                                                                                                                                                      | [PaymentMethodInput](../../Models/Components/PaymentMethodInput.md)                                                                                                                                                                                                                                                  | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |

### Response

**[AccountAddPaymentMethodResponse](../../Models/Requests/AccountAddPaymentMethodResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Boltpay.SDK.Models.Errors.Error           | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.FieldError      | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.CreditCardError | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.SDKException    | 5XX                                       | \*/\*                                     |

## DeletePaymentMethod

Delete an existing payment method. Deleting a payment method does not invalidate or remove it from transactions or orders that are associated with it.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.DeletePaymentMethodAsync(
    xPublishableKey: "<value>",
    id: "D4g3h5tBuVYK9",
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          | Example                                                                                                                                                                                                                                                                                                              |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                      |
| `Id`                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | The ID of the payment method to delete                                                                                                                                                                                                                                                                               | D4g3h5tBuVYK9                                                                                                                                                                                                                                                                                                        |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                                                                                                                      |

### Response

**[AccountPaymentMethodDeleteResponse](../../Models/Requests/AccountPaymentMethodDeleteResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |
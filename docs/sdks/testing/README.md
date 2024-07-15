# Testing
(*Testing*)

## Overview

Endpoints that allow you to generate and retrieve test data to verify certain
flows in non-production environments.


### Available Operations

* [CreateAccount](#createaccount) - Create a test account
* [TestingAccountPhoneGet](#testingaccountphoneget) - Get a random phone number
* [GetCreditCard](#getcreditcard) - Retrieve a test credit card, including its token

## CreateAccount

Create a Bolt shopper account for testing purposes.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK();

var res = await sdk.Testing.CreateAccountAsync(
    security: new TestingAccountCreateSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    xPublishableKey: "<value>",
    accountTestCreationData: new AccountTestCreationData() {
    EmailState = Boltpay.SDK.Models.Components.EmailState.Unverified,
    PhoneState = Boltpay.SDK.Models.Components.PhoneState.Verified,
    IsMigrated = true,
    HasAddress = true,
    HasCreditCard = true,
});

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `security`                                                                                                        | [Boltpay.SDK.Models.Requests.TestingAccountCreateSecurity](../../Models/Requests/TestingAccountCreateSecurity.md) | :heavy_check_mark:                                                                                                | The security requirements to use for the request.                                                                 |
| `XPublishableKey`                                                                                                 | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The publicly viewable identifier used to identify a merchant division.                                            |
| `AccountTestCreationData`                                                                                         | [AccountTestCreationData](../../Models/Components/AccountTestCreationData.md)                                     | :heavy_check_mark:                                                                                                | N/A                                                                                                               |


### Response

**[TestingAccountCreateResponse](../../Models/Requests/TestingAccountCreateResponse.md)**
### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Response4xx  | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |

## TestingAccountPhoneGet

Get a random, fictitious phone number that is not assigned to any existing account.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;

var sdk = new BoltSDK();

var res = await sdk.Testing.TestingAccountPhoneGetAsync(
    security: new TestingAccountPhoneGetSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    xPublishableKey: "<value>");

// handle response
```

### Parameters

| Parameter                                                                                                             | Type                                                                                                                  | Required                                                                                                              | Description                                                                                                           |
| --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| `security`                                                                                                            | [Boltpay.SDK.Models.Requests.TestingAccountPhoneGetSecurity](../../Models/Requests/TestingAccountPhoneGetSecurity.md) | :heavy_check_mark:                                                                                                    | The security requirements to use for the request.                                                                     |
| `XPublishableKey`                                                                                                     | *string*                                                                                                              | :heavy_check_mark:                                                                                                    | The publicly viewable identifier used to identify a merchant division.                                                |


### Response

**[TestingAccountPhoneGetResponse](../../Models/Requests/TestingAccountPhoneGetResponse.md)**
### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Response4xx  | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |

## GetCreditCard

Retrieve test credit card information. This includes its token, which can be used to process payments.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;

var sdk = new BoltSDK();

TestingCreditCardGetRequestBody req = new TestingCreditCardGetRequestBody() {
    Type = Boltpay.SDK.Models.Requests.Type.Approve,
};

var res = await sdk.Testing.GetCreditCardAsync(
    security: new TestingCreditCardGetSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    req);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                         | [TestingCreditCardGetRequestBody](../../Models/Requests/TestingCreditCardGetRequestBody.md)                       | :heavy_check_mark:                                                                                                | The request object to use for the request.                                                                        |
| `security`                                                                                                        | [Boltpay.SDK.Models.Requests.TestingCreditCardGetSecurity](../../Models/Requests/TestingCreditCardGetSecurity.md) | :heavy_check_mark:                                                                                                | The security requirements to use for the request.                                                                 |


### Response

**[TestingCreditCardGetResponse](../../Models/Requests/TestingCreditCardGetResponse.md)**
### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Response4xx  | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |
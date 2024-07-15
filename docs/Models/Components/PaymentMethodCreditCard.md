# PaymentMethodCreditCard


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `DotTag`                                                          | [Models.Components.DotTag](../../Models/Components/DotTag.md)     | :heavy_check_mark:                                                | N/A                                                               | credit_card                                                       |
| `Id`                                                              | *string*                                                          | :heavy_minus_sign:                                                | N/A                                                               | X5h6j8uLpVGK                                                      |
| `BillingAddress`                                                  | [AddressReference](../../Models/Components/AddressReference.md)   | :heavy_check_mark:                                                | N/A                                                               |                                                                   |
| `Network`                                                         | [CreditCardNetwork](../../Models/Components/CreditCardNetwork.md) | :heavy_check_mark:                                                | The credit card's network.                                        | visa                                                              |
| `Last4`                                                           | *string*                                                          | :heavy_check_mark:                                                | The account number's last four digits.                            | 1004                                                              |
| `Expiration`                                                      | *string*                                                          | :heavy_check_mark:                                                | The expiration date, in YYYY-MM format.                           | 2029-03                                                           |
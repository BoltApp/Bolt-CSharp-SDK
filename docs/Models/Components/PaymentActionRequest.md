# PaymentActionRequest


## Fields

| Field                                                                          | Type                                                                           | Required                                                                       | Description                                                                    | Example                                                                        |
| ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ |
| `DotTag`                                                                       | [PaymentActionRequestTag](../../Models/Components/PaymentActionRequestTag.md)  | :heavy_check_mark:                                                             | N/A                                                                            | finalize                                                                       |
| `RedirectResult`                                                               | *string*                                                                       | :heavy_minus_sign:                                                             | Optional redirect result token required for an APM payment (excluding PayPal). | eyJ0cmFuc                                                                      |
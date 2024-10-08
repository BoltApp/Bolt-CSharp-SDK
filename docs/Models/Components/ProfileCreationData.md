# ProfileCreationData

An account's identifying information.


## Fields

| Field                                                      | Type                                                       | Required                                                   | Description                                                | Example                                                    |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| `CreateAccount`                                            | *bool*                                                     | :heavy_check_mark:                                         | Whether or not an account should be created.               | true                                                       |
| `FirstName`                                                | *string*                                                   | :heavy_check_mark:                                         | The given name of the person associated with this profile. | Alice                                                      |
| `LastName`                                                 | *string*                                                   | :heavy_check_mark:                                         | The last name of the person associated with this profile.  | Baker                                                      |
| `Email`                                                    | *string*                                                   | :heavy_check_mark:                                         | The email address asscoiated with this profile.            | alice@example.com                                          |
| `Phone`                                                    | *string*                                                   | :heavy_minus_sign:                                         | The phone number associated with this profile.             | +14155550199                                               |
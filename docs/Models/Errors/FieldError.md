# FieldError

An error that pertains to validation of a specific field in the request.


## Fields

| Field                                                                                                   | Type                                                                                                    | Required                                                                                                | Description                                                                                             | Example                                                                                                 |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `DotTag`                                                                                                | [FieldErrorTag](../../Models/Errors/FieldErrorTag.md)                                                   | :heavy_check_mark:                                                                                      | The type of error returned                                                                              | invalid_input_parameter                                                                                 |
| `Message`                                                                                               | *string*                                                                                                | :heavy_check_mark:                                                                                      | A human-readable error message, which might include information specific to<br/>the request that was made.<br/> | We were unable to process your request.                                                                 |
| `Field`                                                                                                 | *string*                                                                                                | :heavy_check_mark:                                                                                      | The field (in its hierarchical form) that is failing validation.                                        | address.phone                                                                                           |
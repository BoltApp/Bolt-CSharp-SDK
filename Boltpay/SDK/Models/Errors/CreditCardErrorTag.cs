//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Errors
{
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System;
    
    /// <summary>
    /// The type of error returned
    /// </summary>
    public enum CreditCardErrorTag
    {
        [JsonProperty("declined")]
        Declined,
        [JsonProperty("declined_invalid_amount")]
        DeclinedInvalidAmount,
        [JsonProperty("declined_invalid_cvv")]
        DeclinedInvalidCvv,
        [JsonProperty("declined_invalid_merchant")]
        DeclinedInvalidMerchant,
        [JsonProperty("declined_invalid_number")]
        DeclinedInvalidNumber,
        [JsonProperty("declined_expired")]
        DeclinedExpired,
        [JsonProperty("declined_call_issuer")]
        DeclinedCallIssuer,
        [JsonProperty("declined_unsupported")]
        DeclinedUnsupported,
    }

    public static class CreditCardErrorTagExtension
    {
        public static string Value(this CreditCardErrorTag value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreditCardErrorTag ToEnum(this string value)
        {
            foreach(var field in typeof(CreditCardErrorTag).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is CreditCardErrorTag)
                    {
                        return (CreditCardErrorTag)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum CreditCardErrorTag");
        }
    }

}
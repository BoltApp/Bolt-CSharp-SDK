//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Components
{
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System;
    
    public enum PaymentMethodKlarnaAccountTag
    {
        [JsonProperty("klarna_account")]
        KlarnaAccount,
    }

    public static class PaymentMethodKlarnaAccountTagExtension
    {
        public static string Value(this PaymentMethodKlarnaAccountTag value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PaymentMethodKlarnaAccountTag ToEnum(this string value)
        {
            foreach(var field in typeof(PaymentMethodKlarnaAccountTag).GetFields())
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

                    if (enumVal is PaymentMethodKlarnaAccountTag)
                    {
                        return (PaymentMethodKlarnaAccountTag)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum PaymentMethodKlarnaAccountTag");
        }
    }

}
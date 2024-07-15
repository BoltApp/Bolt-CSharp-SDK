//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Utils
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class DecimalStrConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var  nullableType = Nullable.GetUnderlyingType(objectType);
            if (nullableType != null)
            {
                return nullableType == typeof(Decimal);
            }

            return objectType == typeof(Decimal);
        }

        public override object? ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.Value == null)
            {
                return null;
            }

            try {
                return Decimal.Parse(reader.Value.ToString()!);
            } catch (System.FormatException ex) {
                throw new Newtonsoft.Json.JsonSerializationException("Could not parse Decimal", ex);
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("null");
                return;
            }

            writer.WriteValue(((Decimal)value).ToString(CultureInfo.InvariantCulture));
        }
    }
}

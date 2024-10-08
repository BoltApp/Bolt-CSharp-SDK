//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Components
{
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System;
    

    public class AddressReferenceType
    {
        private AddressReferenceType(string value) { Value = value; }

        public string Value { get; private set; }
        
        public static AddressReferenceType Id { get { return new AddressReferenceType("id"); } }
        public static AddressReferenceType Explicit { get { return new AddressReferenceType("explicit"); } }
        public static AddressReferenceType Null { get { return new AddressReferenceType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(AddressReferenceType v) { return v.Value; }
        public static AddressReferenceType FromString(string v) {
            switch(v) {
                case "id": return Id;
                case "explicit": return Explicit;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for AddressReferenceType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((AddressReferenceType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(AddressReference.AddressReferenceConverter))]
    public class AddressReference {
        public AddressReference(AddressReferenceType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public AddressReferenceId? AddressReferenceId { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public AddressReferenceExplicit? AddressReferenceExplicit { get; set; }

        public AddressReferenceType Type { get; set; }


        public static AddressReference CreateId(AddressReferenceId id) {
            AddressReferenceType typ = AddressReferenceType.Id;
        
            string typStr = AddressReferenceType.Id.ToString();
            
            id.DotTag = AddressReferenceIdTagExtension.ToEnum(AddressReferenceType.Id.ToString());
            AddressReference res = new AddressReference(typ);
            res.AddressReferenceId = id;
            return res;
        }
        public static AddressReference CreateExplicit(AddressReferenceExplicit explicitT) {
            AddressReferenceType typ = AddressReferenceType.Explicit;
        
            string typStr = AddressReferenceType.Explicit.ToString();
            
            explicitT.DotTag = AddressReferenceExplicitTagExtension.ToEnum(AddressReferenceType.Explicit.ToString());
            AddressReference res = new AddressReference(typ);
            res.AddressReferenceExplicit = explicitT;
            return res;
        }
        public static AddressReference CreateNull() {
            AddressReferenceType typ = AddressReferenceType.Null;
            return new AddressReference(typ);
        }

        public class AddressReferenceConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(AddressReference);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                string discriminator = jo.GetValue(".tag")?.ToString() ?? throw new ArgumentNullException("Could not find discriminator field.");
                if (discriminator == AddressReferenceType.Id.ToString())
                {
                    AddressReferenceId? addressReferenceID = ResponseBodyDeserializer.Deserialize<AddressReferenceId>(jo.ToString());
                    return CreateId(addressReferenceID!);
                }
                if (discriminator == AddressReferenceType.Explicit.ToString())
                {
                    AddressReferenceExplicit? addressReferenceExplicit = ResponseBodyDeserializer.Deserialize<AddressReferenceExplicit>(jo.ToString());
                    return CreateExplicit(addressReferenceExplicit!);
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                AddressReference res = (AddressReference)value;
                if (AddressReferenceType.FromString(res.Type).Equals(AddressReferenceType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.AddressReferenceId != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.AddressReferenceId));
                    return;
                }
                if (res.AddressReferenceExplicit != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.AddressReferenceExplicit));
                    return;
                }

            }

        }

    }
}
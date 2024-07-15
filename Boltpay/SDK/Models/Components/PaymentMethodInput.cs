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
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System;
    

    public class PaymentMethodInputType
    {
        private PaymentMethodInputType(string value) { Value = value; }

        public string Value { get; private set; }
        
        public static PaymentMethodInputType CreditCard { get { return new PaymentMethodInputType("credit_card"); } }
        public static PaymentMethodInputType Paypal { get { return new PaymentMethodInputType("paypal"); } }
        public static PaymentMethodInputType Affirm { get { return new PaymentMethodInputType("affirm"); } }
        public static PaymentMethodInputType Afterpay { get { return new PaymentMethodInputType("afterpay"); } }
        public static PaymentMethodInputType Klarna { get { return new PaymentMethodInputType("klarna"); } }
        public static PaymentMethodInputType KlarnaAccount { get { return new PaymentMethodInputType("klarna_account"); } }
        public static PaymentMethodInputType KlarnaPaynow { get { return new PaymentMethodInputType("klarna_paynow"); } }
        public static PaymentMethodInputType Null { get { return new PaymentMethodInputType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(PaymentMethodInputType v) { return v.Value; }
        public static PaymentMethodInputType FromString(string v) {
            switch(v) {
                case "credit_card": return CreditCard;
                case "paypal": return Paypal;
                case "affirm": return Affirm;
                case "afterpay": return Afterpay;
                case "klarna": return Klarna;
                case "klarna_account": return KlarnaAccount;
                case "klarna_paynow": return KlarnaPaynow;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for PaymentMethodInputType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((PaymentMethodInputType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(PaymentMethodInput.PaymentMethodInputConverter))]
    public class PaymentMethodInput {
        public PaymentMethodInput(PaymentMethodInputType type) {
            Type = type;
        }
        public PaymentMethodCreditCardInput? PaymentMethodCreditCardInput { get; set; }
        public PaymentMethodPaypal? PaymentMethodPaypal { get; set; }
        public PaymentMethodAffirm? PaymentMethodAffirm { get; set; }
        public PaymentMethodAfterpay? PaymentMethodAfterpay { get; set; }
        public PaymentMethodKlarna? PaymentMethodKlarna { get; set; }
        public PaymentMethodKlarnaAccount? PaymentMethodKlarnaAccount { get; set; }
        public PaymentMethodKlarnaPaynow? PaymentMethodKlarnaPaynow { get; set; }

        public PaymentMethodInputType Type { get; set; }


        public static PaymentMethodInput CreateCreditCard(PaymentMethodCreditCardInput creditCard) {
            PaymentMethodInputType typ = PaymentMethodInputType.CreditCard;
        
            string typStr = PaymentMethodInputType.CreditCard.ToString();
            
            creditCard.DotTag = Models.Components.DotTagExtension.ToEnum(PaymentMethodInputType.CreditCard.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodCreditCardInput = creditCard;
            return res;
        }
        public static PaymentMethodInput CreatePaypal(PaymentMethodPaypal paypal) {
            PaymentMethodInputType typ = PaymentMethodInputType.Paypal;
        
            string typStr = PaymentMethodInputType.Paypal.ToString();
            
            paypal.DotTag = PaymentMethodPaypalTagExtension.ToEnum(PaymentMethodInputType.Paypal.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodPaypal = paypal;
            return res;
        }
        public static PaymentMethodInput CreateAffirm(PaymentMethodAffirm affirm) {
            PaymentMethodInputType typ = PaymentMethodInputType.Affirm;
        
            string typStr = PaymentMethodInputType.Affirm.ToString();
            
            affirm.DotTag = PaymentMethodAffirmTagExtension.ToEnum(PaymentMethodInputType.Affirm.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodAffirm = affirm;
            return res;
        }
        public static PaymentMethodInput CreateAfterpay(PaymentMethodAfterpay afterpay) {
            PaymentMethodInputType typ = PaymentMethodInputType.Afterpay;
        
            string typStr = PaymentMethodInputType.Afterpay.ToString();
            
            afterpay.DotTag = PaymentMethodAfterpayTagExtension.ToEnum(PaymentMethodInputType.Afterpay.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodAfterpay = afterpay;
            return res;
        }
        public static PaymentMethodInput CreateKlarna(PaymentMethodKlarna klarna) {
            PaymentMethodInputType typ = PaymentMethodInputType.Klarna;
        
            string typStr = PaymentMethodInputType.Klarna.ToString();
            
            klarna.DotTag = PaymentMethodKlarnaTagExtension.ToEnum(PaymentMethodInputType.Klarna.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodKlarna = klarna;
            return res;
        }
        public static PaymentMethodInput CreateKlarnaAccount(PaymentMethodKlarnaAccount klarnaAccount) {
            PaymentMethodInputType typ = PaymentMethodInputType.KlarnaAccount;
        
            string typStr = PaymentMethodInputType.KlarnaAccount.ToString();
            
            klarnaAccount.DotTag = PaymentMethodKlarnaAccountTagExtension.ToEnum(PaymentMethodInputType.KlarnaAccount.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodKlarnaAccount = klarnaAccount;
            return res;
        }
        public static PaymentMethodInput CreateKlarnaPaynow(PaymentMethodKlarnaPaynow klarnaPaynow) {
            PaymentMethodInputType typ = PaymentMethodInputType.KlarnaPaynow;
        
            string typStr = PaymentMethodInputType.KlarnaPaynow.ToString();
            
            klarnaPaynow.DotTag = PaymentMethodKlarnaPaynowTagExtension.ToEnum(PaymentMethodInputType.KlarnaPaynow.ToString());
            PaymentMethodInput res = new PaymentMethodInput(typ);
            res.PaymentMethodKlarnaPaynow = klarnaPaynow;
            return res;
        }
        public static PaymentMethodInput CreateNull() {
            PaymentMethodInputType typ = PaymentMethodInputType.Null;
            return new PaymentMethodInput(typ);
        }

        public class PaymentMethodInputConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(PaymentMethodInput);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                string discriminator = jo.GetValue(".tag")?.ToString() ?? throw new ArgumentNullException("Could not find discriminator field.");
                if (discriminator == PaymentMethodInputType.CreditCard.ToString())
                {
                    PaymentMethodCreditCardInput? paymentMethodCreditCardInput = ResponseBodyDeserializer.Deserialize<PaymentMethodCreditCardInput>(jo.ToString());
                    return CreateCreditCard(paymentMethodCreditCardInput!);
                }
                if (discriminator == PaymentMethodInputType.Paypal.ToString())
                {
                    PaymentMethodPaypal? paymentMethodPaypal = ResponseBodyDeserializer.Deserialize<PaymentMethodPaypal>(jo.ToString());
                    return CreatePaypal(paymentMethodPaypal!);
                }
                if (discriminator == PaymentMethodInputType.Affirm.ToString())
                {
                    PaymentMethodAffirm? paymentMethodAffirm = ResponseBodyDeserializer.Deserialize<PaymentMethodAffirm>(jo.ToString());
                    return CreateAffirm(paymentMethodAffirm!);
                }
                if (discriminator == PaymentMethodInputType.Afterpay.ToString())
                {
                    PaymentMethodAfterpay? paymentMethodAfterpay = ResponseBodyDeserializer.Deserialize<PaymentMethodAfterpay>(jo.ToString());
                    return CreateAfterpay(paymentMethodAfterpay!);
                }
                if (discriminator == PaymentMethodInputType.Klarna.ToString())
                {
                    PaymentMethodKlarna? paymentMethodKlarna = ResponseBodyDeserializer.Deserialize<PaymentMethodKlarna>(jo.ToString());
                    return CreateKlarna(paymentMethodKlarna!);
                }
                if (discriminator == PaymentMethodInputType.KlarnaAccount.ToString())
                {
                    PaymentMethodKlarnaAccount? paymentMethodKlarnaAccount = ResponseBodyDeserializer.Deserialize<PaymentMethodKlarnaAccount>(jo.ToString());
                    return CreateKlarnaAccount(paymentMethodKlarnaAccount!);
                }
                if (discriminator == PaymentMethodInputType.KlarnaPaynow.ToString())
                {
                    PaymentMethodKlarnaPaynow? paymentMethodKlarnaPaynow = ResponseBodyDeserializer.Deserialize<PaymentMethodKlarnaPaynow>(jo.ToString());
                    return CreateKlarnaPaynow(paymentMethodKlarnaPaynow!);
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                PaymentMethodInput res = (PaymentMethodInput)value;
                if (PaymentMethodInputType.FromString(res.Type).Equals(PaymentMethodInputType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.PaymentMethodCreditCardInput != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodCreditCardInput));
                    return;
                }
                if (res.PaymentMethodPaypal != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodPaypal));
                    return;
                }
                if (res.PaymentMethodAffirm != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodAffirm));
                    return;
                }
                if (res.PaymentMethodAfterpay != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodAfterpay));
                    return;
                }
                if (res.PaymentMethodKlarna != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodKlarna));
                    return;
                }
                if (res.PaymentMethodKlarnaAccount != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodKlarnaAccount));
                    return;
                }
                if (res.PaymentMethodKlarnaPaynow != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.PaymentMethodKlarnaPaynow));
                    return;
                }

            }

        }

    }
}
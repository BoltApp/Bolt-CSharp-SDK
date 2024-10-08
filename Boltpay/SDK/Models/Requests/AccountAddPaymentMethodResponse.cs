//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Requests
{
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    
    public class AccountAddPaymentMethodResponse
    {

        [JsonProperty("-")]
        public HTTPMetadata HttpMeta { get; set; } = default!;

        /// <summary>
        /// The payment method was successfully added
        /// </summary>
        public PaymentMethod? PaymentMethod { get; set; }

        public PaymentMethodCreditCard? GetPaymentMethodCreditCard()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodCreditCard : null;
        }

        public PaymentMethodPaypalOutput? GetPaymentMethodPaypal()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodPaypalOutput : null;
        }

        public PaymentMethodAffirmOutput? GetPaymentMethodAffirm()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodAffirmOutput : null;
        }

        public PaymentMethodAfterpayOutput? GetPaymentMethodAfterpay()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodAfterpayOutput : null;
        }

        public PaymentMethodKlarnaOutput? GetPaymentMethodKlarna()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodKlarnaOutput : null;
        }

        public PaymentMethodKlarnaAccountOutput? GetPaymentMethodKlarnaAccount()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodKlarnaAccountOutput : null;
        }

        public PaymentMethodKlarnaPaynowOutput? GetPaymentMethodKlarnaPaynow()
        {
            return PaymentMethod != null ? PaymentMethod.PaymentMethodKlarnaPaynowOutput : null;
        }
    }
}
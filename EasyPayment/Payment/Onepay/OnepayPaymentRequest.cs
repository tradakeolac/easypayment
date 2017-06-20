namespace EasyPayment.Payment.Onepay
{
    using System;

    public class OnepayPaymentRequest : PaymentRequest
    {
        public OnepayPaymentRequest()
        {
            MerchRef = Guid.NewGuid();
        }
        public Guid MerchRef { get; set; }
    }
}

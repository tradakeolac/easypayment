namespace EasyPayment.Payment.Paypal
{
    using System;
    using System.Collections.Specialized;
    
    public class PaypalProcessor : IPaymentProcessor
    {
        public PaymentRequestResult Process(PaymentRequest payment)
        {
            // NotImplemented
            throw new NotImplementedException();
        }

        public PaymentResponseResult Verify(NameValueCollection query)
        {
            // NotImplemented
            throw new NotImplementedException();
        }
    }
}

namespace EasyPayment.Payment
{
    using System.Collections.Specialized;

    public interface IPaymentProcessor
    {
        PaymentRequestResult Process(PaymentRequest payment);
        PaymentResponseResult Verify(NameValueCollection query);
    }
}

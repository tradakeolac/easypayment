namespace EasyPayment.Configuration.Payment
{
    public interface IPaymentProviderSection
    {
        string Default { get; set; }
        PaymentProviderCollection Payments { get; }
    }
}
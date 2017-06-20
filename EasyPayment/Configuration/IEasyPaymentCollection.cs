namespace EasyPayment.Configuration
{
    public interface IEasyPaymentCollection
    {
        IEasyPaymentElement this[string key] { get; }
    }
}
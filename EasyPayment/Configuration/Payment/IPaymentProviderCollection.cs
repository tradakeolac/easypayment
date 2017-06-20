namespace EasyPayment.Configuration.Payment
{
    public interface IPaymentProviderCollection
    {
        IPaymentProviderElement this[string key] { get; }
    }
}
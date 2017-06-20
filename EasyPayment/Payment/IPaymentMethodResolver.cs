namespace EasyPayment.Payment
{
    public interface IPaymentMethodResolver
    {
        IPaymentProcessor Resolve(string provider);
    }
}

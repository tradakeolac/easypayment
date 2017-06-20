using System.Configuration;

namespace EasyPayment.Configuration.Payment
{
    public class PaymentProviderCollection : ConfigurationElementCollection, IPaymentProviderCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProxyPaymentProviderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProxyPaymentProviderElement) element).Instance.ProviderName;
        }

        public new IPaymentProviderElement this[string key]
        {
            get { return ((ProxyPaymentProviderElement) BaseGet(key)).Instance; }
        }
    }
}
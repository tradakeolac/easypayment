using System.Configuration;

namespace EasyPayment.Configuration
{

    public class EasyPaymentCollection : ConfigurationElementCollection, IEasyPaymentCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EasyPaymentElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IEasyPaymentElement) element).Key;
        }

        public new IEasyPaymentElement this[string key]
        {
            get { return BaseGet(key) as IEasyPaymentElement; }
        }
    }
}
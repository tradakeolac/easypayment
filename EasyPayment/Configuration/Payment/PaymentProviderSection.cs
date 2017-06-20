using System.Configuration;

namespace EasyPayment.Configuration.Payment
{
    public class PaymentProviderSection : ConfigurationSection, IPaymentProviderSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(PaymentProviderCollection))]
        public PaymentProviderCollection Payments
        {
            get { return (PaymentProviderCollection)base[""]; }
        }

        [ConfigurationProperty("default")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
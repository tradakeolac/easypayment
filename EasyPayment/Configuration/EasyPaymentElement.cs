using System.Configuration;

namespace EasyPayment.Configuration
{
    public class EasyPaymentElement : ConfigurationElement, IEasyPaymentElement
    {
        [ConfigurationProperty("key")]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
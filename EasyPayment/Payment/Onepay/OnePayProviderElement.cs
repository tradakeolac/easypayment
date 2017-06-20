namespace EasyPayment.Payment.Onepay
{
    using System.Configuration;
    using EasyPayment.Configuration.Payment;
    using EasyPayment.Extensions;

    public class OnepayProviderElement : PaymentProviderElement
    {
        [ConfigurationProperty("version")]
        public string Version
        {
            get { return this["version"].To<string>(); }
            set { this["version"] = value; }
        }

        [ConfigurationProperty("command")]
        public string Command
        {
            get { return this["command"].To<string>(); }
            set { this["command"] = value; }
        }

        [ConfigurationProperty("accessCode")]
        public string AccessCode
        {
            get { return this["accessCode"].To<string>(); }
            set { this["accessCode"] = value; }
        }

        [ConfigurationProperty("merchant")]
        public string Merchant
        {
            get { return this["merchant"].To<string>(); }
            set { this["merchant"] = value; }
        }
    }
}
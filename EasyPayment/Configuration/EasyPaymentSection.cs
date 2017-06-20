namespace EasyPayment.Configuration
{
    using System.Configuration;

    public class EasyPaymentSection : ConfigurationSection, IEasyPaymentSection
    {
        [ConfigurationProperty("settings", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(EasyPaymentCollection))]
        public EasyPaymentCollection Settings
        {
            get { return (EasyPaymentCollection)base["settings"]; }
        }
    }
}
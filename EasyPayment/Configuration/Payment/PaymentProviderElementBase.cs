using System.Configuration;
using System.Xml;

namespace EasyPayment.Configuration.Payment
{
    // - Implement multiple ConfigurationElement in a collection
    // http://code.dblock.org/2009/02/18/nesting-multiple-configurationelement-types-in-a-configurationelementcollection.html

    /// <summary>
    /// Base class to define payment provider element in web configuration 
    /// </summary>
    public abstract class PaymentProviderElementBase : ConfigurationElement, IPaymentProviderElement
    {
        [ConfigurationProperty("providerName")]
        public string ProviderName
        {
            get { return (string)this["providerName"]; }
            set { this["providerName"] = value; }
        }

        [ConfigurationProperty("providerUrl")]
        public string ProviderUrl
        {
            get { return (string)this["providerUrl"]; }
            set { this["providerUrl"] = value; }
        }

        [ConfigurationProperty("returnUrl")]
        public string ReturnUrl
        {
            get { return (string)this["returnUrl"]; }
            set { this["returnUrl"] = value; }
        }

        [ConfigurationProperty("salt")]
        public string Salt
        {
            get { return (string)this["salt"]; }
            set { this["salt"] = value; }
        }

        [ConfigurationProperty("type")]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("logoUrl")]
        public string LogoUrl
        {
            get { return (string)this["logoUrl"]; }
            set { this["logoUrl"] = value; }
        }

        [ConfigurationProperty("elementProvider")]
        public string ElementProvider
        {
            get { return (string)this["elementProvider"]; }
            set { this["elementProvider"] = value; }
        }

        public void ProxyDeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            this.DeserializeElement(reader, serializeCollectionKey);
        }
    }
}
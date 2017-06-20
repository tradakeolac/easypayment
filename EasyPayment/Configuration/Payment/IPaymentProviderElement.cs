using System.Xml;

namespace EasyPayment.Configuration.Payment
{
    public interface IPaymentProviderElement
    {
        string ProviderName { get; set; }

        string ProviderUrl { get; set; }

        string ReturnUrl { get; set; }

        string Salt { get; set; }

        string Type { get; set; }

        string ElementProvider { get; set; }

        void ProxyDeserializeElement(XmlReader reader, bool serializeCollectionKey);
    }
}

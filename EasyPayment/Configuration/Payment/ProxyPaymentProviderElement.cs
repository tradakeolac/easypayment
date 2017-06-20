namespace EasyPayment.Configuration.Payment
{
    using System;
    using System.Configuration;
    using System.Xml;

    public class ProxyPaymentProviderElement : ConfigurationElement, IPaymentProviderElement
    {
        private IPaymentProviderElement _realProvider;

        public IPaymentProviderElement Instance
        {
            get
            {
                return _realProvider;
            }
        }

        public string ElementProvider
        {
            get { return Instance.ElementProvider; }
            set { Instance.ElementProvider = value; }
        }

        public string ProviderName
        {
            set { Instance.ProviderName = value; }
            get { return Instance.ProviderName; }
        }

        public string ProviderUrl
        {
            set { Instance.ProviderUrl = value; }
            get { return Instance.ProviderUrl; }
        }

        public string ReturnUrl
        {
            set { Instance.ReturnUrl = value; }
            get { return Instance.ReturnUrl; }
        }

        public string Salt
        {
            set { Instance.Salt = value; }
            get { return Instance.Salt; }
        }

        public string Type
        {
            set { Instance.Type = value; }
            get { return Instance.Type; }
        }

        public void ProxyDeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            Instance.ProxyDeserializeElement(reader, serializeCollectionKey);
        }

        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            var elementTypeAttribute = reader.GetAttribute("elementProvider");
            Type elementType = !string.IsNullOrWhiteSpace(elementTypeAttribute)
                ? System.Type.GetType(elementTypeAttribute)
                : typeof(PaymentProviderElement);

            _realProvider = (IPaymentProviderElement)(Activator.CreateInstance(elementType));

            Instance.ProxyDeserializeElement(reader, serializeCollectionKey);
        }
    }
}
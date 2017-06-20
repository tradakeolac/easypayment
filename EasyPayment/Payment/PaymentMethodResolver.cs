namespace EasyPayment.Payment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentMethodResolver : IPaymentMethodResolver
    {
        private readonly IEnumerable<Lazy<IPaymentProcessor, PaymentProviderMetadata>> _paymentServices;

        public PaymentMethodResolver(IEnumerable<Lazy<IPaymentProcessor, PaymentProviderMetadata>> services)
        {
            this._paymentServices = services;
        }

        public virtual IPaymentProcessor Resolve(string provider)
        {
            return this._paymentServices != null
                ? this._paymentServices.FirstOrDefault(s => s.Metadata.Provider.Equals(provider, StringComparison.CurrentCultureIgnoreCase)).Value
                : null;
        }
    }
}
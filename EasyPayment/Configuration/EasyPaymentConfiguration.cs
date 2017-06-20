namespace EasyPayment.Configuration
{
    using EasyPayment.Configuration;
    using EasyPayment.Extensions;

    public class EasyPaymentConfiguration : IEasyPaymentConfiguration
    {
        private readonly IEasyPaymentSection EasyPaymentSection;
        public EasyPaymentConfiguration(IEasyPaymentSection configSection)
        {
            this.EasyPaymentSection = configSection;
        }

        public string CacheProvider
        {
            get
            {
                return EasyPaymentSection.Settings["cacheProvider"].Value;
            }
        }

        public int DefaultExpiredCachingTime
        {
            get
            {
                return EasyPaymentSection.Settings["defaultCachedExpiredTime"].Value.To<int>();
            }
        }

        public string ImplementedRepositoriesAssembly
        {
            get
            {
                return EasyPaymentSection.Settings["implementedRepositoriesAssembly"].Value;
            }
        }

        public string SqlGeneratorProvider
        {
            get
            {
                return EasyPaymentSection.Settings["sqlgeneratorProvider"].Value;
            }
        }
    }
}

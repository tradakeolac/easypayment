namespace EasyPayment.Configuration
{
    public interface IEasyPaymentConfiguration
    {
        string SqlGeneratorProvider { get;}
        string ImplementedRepositoriesAssembly { get; }
        string CacheProvider { get; }
        int DefaultExpiredCachingTime { get; }
    }
}

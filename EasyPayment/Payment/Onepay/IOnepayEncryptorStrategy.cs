namespace EasyPayment.Payment.Onepay
{
    using System.Collections.Generic;

    public interface IOnepayEncryptorStrategy
    {
        string MakeToken(SortedList<string, string> onePayParams, string salt);
    }
}

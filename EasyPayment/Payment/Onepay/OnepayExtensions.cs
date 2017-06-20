namespace EasyPayment.Payment.Onepay
{
    using System.Collections.Generic;

    internal static class OnepayExtensions
    {

        /// <summary>
        /// Extension method to add onepay params
        /// </summary>
        /// <param name="src"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        internal static void AddOnePayParam(this SortedList<string, string> src, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                src.Add(key, value);
        }
    }
}

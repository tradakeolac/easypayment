namespace EasyPayment.Payment.Onepay
{
    using System;
    using System.Collections.Generic;

    internal class OnepayStringComparable : IComparer<string>
    {
        /*
         <summary>Customised Compare Class</summary>
         <remarks>
         <para>
         The Virtual Payment Client need to use an Ordinal comparison to Sort on 
         the field names to create the SHA256 Signature for validation of the message. 
         This class provides a Compare method that is used to allow the sorted list 
         to be ordered using an Ordinal comparison.
         </para>
         </remarks>
         */

        public int Compare(string a, string b)
        {
            /*
             <summary>Compare method using Ordinal comparison</summary>
             <param name="a">The first string in the comparison.</param>
             <param name="b">The second string in the comparison.</param>
             <returns>An int containing the result of the comparison.</returns>
             */

            // Return if we are comparing the same object or one of the 
            // objects is null, since we don't need to go any further.
            if (a == b) return 0;
            if (a == null) return -1;
            if (b == null) return 1;

            // Ensure we have string to compare
            var sa = a as string;
            var sb = b as string;

            // Get the CompareInfo object to use for comparing
            var myComparer = System.Globalization.CompareInfo.GetCompareInfo("en-US");
            if (sa != null && sb != null)
            {
                // Compare using an Ordinal Comparison.
                return myComparer.Compare(sa, sb, System.Globalization.CompareOptions.Ordinal);
            }
            throw new ArgumentException("a and b should be strings.");
        }
    }
}

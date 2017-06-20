namespace EasyPayment.Payment.Onepay
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class Sha25Onepay6Encryptor : IOnepayEncryptorStrategy
    {
        public string MakeToken(SortedList<string, string> onePayParams, string salt)
        {
            // Hex Decode the Secure Secret for use in using the HMACSHA256 hasher
            // hex decoding eliminates this source of error as it is independent of the character encoding
            // hex decoding is precise in converting to a byte array and is the preferred form for representing binary values as hex strings. 
            byte[] convertedHash = new byte[salt.Length / 2];
            for (int i = 0; i < salt.Length / 2; i++)
            {
                convertedHash[i] = (byte)Int32.Parse(salt.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }

            // Build string from collection in preperation to be hashed
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in onePayParams)
            {
                if (kvp.Key.StartsWith("vpc_", StringComparison.Ordinal) || kvp.Key.StartsWith("user_", StringComparison.Ordinal))
                    sb.Append(kvp.Key + "=" + kvp.Value + "&");
            }
            // remove trailing & from string
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            // Create secureHash on string
            var hexHash = new StringBuilder();
            using (HMACSHA256 hasher = new HMACSHA256(convertedHash))
            {
                var hashValue = hasher.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                foreach (byte b in hashValue)
                {
                    hexHash.Append(b.ToString("X2"));
                }
            }
            return hexHash.ToString();
        }
    }
}

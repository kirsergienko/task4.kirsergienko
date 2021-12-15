using System.Security.Cryptography;
using System.Text;
using SHA3.Net;

namespace game
{
    class KeyGeneration
    {
        public static string GenerateKey()
        {
            byte[] k = new byte[32];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(k);
            string key = "";
            for (int i = 0; i < k.Length; i++)
            {
                key += $"{k[i]:x2}";
            }
            return key;
        }

        public static string GenerateHMAC(string key, string move)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(move + key);
            var sha3 = Sha3.Sha3256();
            byte[] h = sha3.ComputeHash(bytes);
            string hmac = "";
            foreach (var b in h)
            {
                hmac += $"{b:x2}";
            }
            return hmac;
        }
    }
}

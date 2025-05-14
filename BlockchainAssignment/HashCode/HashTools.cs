using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace BlockchainAssignment.HashCode
{
    public static class HashTools
    {
        public static string ByteArrayToString(byte[] ba)
        {
            var sb = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length / 2)
                             .Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16))
                             .ToArray();
        }

        public static string CombineHash(string h1, string h2)
        {
            byte[] b1 = StringToByteArray(h1);
            byte[] b2 = StringToByteArray(h2);
            using (SHA256 sha256 = SHA256.Create())
            {
                return ByteArrayToString(sha256.ComputeHash(b1.Concat(b2).ToArray()));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using BlockchainAssignment.HashCode;

namespace BlockchainAssignment.Wallet
{
    class Wallet
    {
        public string publicID;

        public Wallet(out string privateKey)
        {
            privateKey = string.Empty;
            var parms = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowPlaintextExport,
                KeyUsage = CngKeyUsages.Signing
            };
            CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, null, parms);

            byte[] blob = key.Export(CngKeyBlobFormat.EccPrivateBlob);
            publicID = Convert.ToBase64String(blob.Skip(8).Take(blob.Length - 40).ToArray());
            privateKey = Convert.ToBase64String(blob.Skip(72).ToArray());
        }

        public static bool ValidatePrivateKey(string priv, string pub)
        {
            const string testHash = "0000abc1e11b8d37c1e1232a2ea6d290cddb0c678058c37aa766f813cbbb366e";
            if (priv.Length != 44 || pub.Length != 88)
                return false;
            string sig = CreateSignature(pub, priv, testHash);
            return ValidateSignature(pub, testHash, sig);
        }

        public static bool ValidateSignature(string publicID, string datahex, string datasig)
        {
            if (publicID == "Mine Rewards")
                publicID = "QfF3+9GgTxyGLvb+ScOAI6nJxBh8IyZbeD0r6BJBMyabZmyuP82yrSLKMq/F05OG0VZ4gg63uHFZUKzCu3wZuA==";

            if (publicID.Length != 88 || datasig == "null")
                return false;

            CngKey key = createKey(publicID);
            if (key == null) return false;

            using (var dsa = new ECDsaCng(key))
            {
                byte[] db = HashTools.StringToByteArray(datahex);
                byte[] sb = Convert.FromBase64String(datasig);
                return dsa.VerifyData(db, sb);
            }
        }

        public static string CreateSignature(string publicID, string privateKey, string datahex)
        {
            CngKey key = createKey(publicID, privateKey);
            if (key == null) return "null";

            using (var dsa = new ECDsaCng(key))
            {
                byte[] db = HashTools.StringToByteArray(datahex);
                byte[] sb = dsa.SignData(db);
                return Convert.ToBase64String(sb);
            }
        }

        private static CngKey createKey(string publicID, string privateKey = "")
        {
            try
            {
                if (publicID == "Mine Rewards" && privateKey == "")
                {
                    publicID = "QfF3+9GgTxyGLvb+ScOAI6nJxBh8IyZbeD0r6BJBMyabZmyuP82yrSLKMq/F05OG0VZ4gg63uHFZUKzCu3wZuA==";
                    privateKey = "mkT1Iu3YF4NSruHBptVytyDkNcxwemrkclndJH0+73o=";
                }
                byte[] header = new byte[] { 69, 67, 83, 49, 32, 0, 0, 0 };
                byte[] pubBytes = Convert.FromBase64String(publicID);
                byte[] blob1 = new byte[72];
                header.CopyTo(blob1, 0);
                pubBytes.CopyTo(blob1, header.Length);

                if (!string.IsNullOrEmpty(privateKey))
                {
                    blob1[3] = 50;
                    byte[] privBytes = Convert.FromBase64String(privateKey);
                    byte[] blob2 = new byte[104];
                    blob1.CopyTo(blob2, 0);
                    privBytes.CopyTo(blob2, blob1.Length);
                    return CngKey.Import(blob2, CngKeyBlobFormat.EccPrivateBlob);
                }

                return CngKey.Import(blob1, CngKeyBlobFormat.EccPublicBlob);
            }
            catch
            {
                return null;
            }
        }
    }
}
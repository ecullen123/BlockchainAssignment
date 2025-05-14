using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    internal class Transaction
    {
        public string Hash { get; private set; }
        public string Signature { get; private set; }
        public string SenderAddress { get; }
        public string RecipientAddress { get; }
        public DateTime Timestamp { get; }
        public decimal Amount { get; }
        public decimal Fee { get; }

        public Transaction(
            string senderAddress,
            string recipientAddress,
            decimal amount,
            decimal fee,
            string senderPrivateKey)
        {
            SenderAddress = senderAddress;
            RecipientAddress = recipientAddress;
            Amount = amount;
            Fee = fee;
            Timestamp = DateTime.Now;

            Hash = GenerateHash();
            Signature = BlockchainAssignment.Wallet.Wallet.CreateSignature(
                SenderAddress, senderPrivateKey, Hash);
        }

        private byte[] ComputeRawHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string raw = SenderAddress + RecipientAddress + Amount + Fee + Timestamp;
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(raw));
            }
        }

        private string GenerateHash()
        {
            byte[] rawBytes = ComputeRawHash();
            var sb = new StringBuilder(rawBytes.Length * 2);
            foreach (byte b in rawBytes)
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        public string CalculateHash()
        {
            return GenerateHash();
        }

        public string GetTransactionData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Transaction Hash: {Hash}");
            sb.AppendLine($"Signature: {Signature}");
            sb.AppendLine($"Sender: {SenderAddress}");
            sb.AppendLine($"Recipient: {RecipientAddress}");
            sb.AppendLine($"Amount: {Amount}");
            sb.AppendLine($"Fee: {Fee}");
            sb.AppendLine($"Timestamp: {Timestamp}");
            return sb.ToString();
        }
    }
}
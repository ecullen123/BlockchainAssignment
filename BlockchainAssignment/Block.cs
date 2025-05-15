using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlockchainAssignment.HashCode;

namespace BlockchainAssignment
{
    internal class Block
    {
        public DateTime Timestamp { get; }
        public int Index { get; }
        public string Hash { get; set; }
        public string PreviousHash { get; }
        public List<Transaction> Transactions { get; }
        public long Nonce { get; set; }
        public string MerkleRoot { get; private set; }
        public static int Difficulty { get; } = 4;
        public static decimal Reward { get; } = 50m;

        /// <summary>
        /// Core constructor that optionally skips mining.
        /// </summary>
        public Block(bool skipMining)
        {
            Index = 0;
            PreviousHash = string.Empty;
            Transactions = new List<Transaction>();
            Timestamp = DateTime.Now;
            MerkleRoot = ComputeMerkleRoot(Transactions);
            if (!skipMining)
                Mine();
        }

        /// <summary>
        /// Default: create genesis block AND mine immediately.
        /// </summary>
        public Block() : this(skipMining: false) { }

        /// <summary>
        /// Create next block from a previous block, reward + pending transactions.
        /// </summary>
        public Block(Block previousBlock, List<Transaction> pendingTxs, string minerAddress)
        {
            PreviousHash = previousBlock.Hash;
            Index = previousBlock.Index + 1;
            Timestamp = DateTime.Now;

            // Reward + fees
            decimal totalFees = pendingTxs.Sum(tx => tx.Fee);
            var rewardTx = new Transaction(
                "Mine Rewards",
                minerAddress,
                Reward + totalFees,
                0m,
                string.Empty);

            Transactions = new List<Transaction> { rewardTx };
            Transactions.AddRange(pendingTxs);

            MerkleRoot = ComputeMerkleRoot(Transactions);
            Mine();
        }

        public static string ComputeMerkleRoot(List<Transaction> txs)
        {
            if (txs == null || txs.Count == 0)
                return string.Empty;
            List<string> hashes = txs.Select(t => t.Hash).ToList();
            while (hashes.Count > 1)
            {
                List<string> next = new List<string>();
                for (int i = 0; i < hashes.Count; i += 2)
                {
                    if (i + 1 < hashes.Count)
                        next.Add(HashTools.CombineHash(hashes[i], hashes[i + 1]));
                    else
                        next.Add(hashes[i]);
                }
                hashes = next;
            }
            return hashes[0];
        }

        /// <summary>
        /// Performs parallel proof-of-work across all CPU cores.
        /// </summary>
        public void Mine()
        {
            string target = new string('0', Difficulty);
            long nextNonce = -1;
            string foundHash = null;
            long foundNonce = 0;

            using (var cts = new CancellationTokenSource())
            {
                int threadCount = Environment.ProcessorCount;
                var tasks = new Task[threadCount];

                for (int i = 0; i < threadCount; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        while (!cts.Token.IsCancellationRequested)
                        {
                            long nonce = Interlocked.Increment(ref nextNonce);
                            string hash = ComputeHashForNonce(nonce);
                            if (hash.StartsWith(target))
                            {
                                foundHash = hash;
                                foundNonce = nonce;
                                cts.Cancel();
                                break;
                            }
                        }
                    }, cts.Token);
                }

                // Wait for all threads to finish, suppress TaskCanceledExceptions
                try
                {
                    Task.WaitAll(tasks);
                }
                catch (AggregateException ae)
                {
                    ae.Handle(ex => ex is TaskCanceledException);
                }
            }

            Nonce = foundNonce;
            Hash = foundHash;
        }

        /// <summary>
        /// Original single-threaded mining implementation.
        /// </summary>
        public void MineSerial()
        {
            string target = new string('0', Difficulty);
            long nonce = 0;
            string hash;
            do
            {
                hash = ComputeHashForNonce(nonce++);
            }
            while (!hash.StartsWith(target));

            Nonce = nonce - 1;
            Hash = hash;
        }

        /// <summary>
        /// Compute the block hash for a given nonce without modifying state.
        /// </summary>
        public string ComputeHashForNonce(long nonce)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var raw = new StringBuilder()
                    .Append(Index)
                    .Append(Timestamp)
                    .Append(PreviousHash)
                    .Append(MerkleRoot)
                    .Append(nonce);

                foreach (var tx in Transactions)
                    raw.Append(tx.Hash);

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(raw.ToString()));
                var hex = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            }
        }

        public string CalculateHash()
        {
            return ComputeHashForNonce(Nonce);
        }

        public string GetBlockData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Index: {Index}");
            sb.AppendLine($"Previous Hash: {PreviousHash}");
            sb.AppendLine($"Merkle Root: {MerkleRoot}");
            sb.AppendLine($"Hash: {Hash}");
            sb.AppendLine($"Nonce: {Nonce}");
            sb.AppendLine($"Difficulty: {Difficulty}");
            sb.AppendLine($"Timestamp: {Timestamp}");
            sb.AppendLine("Transactions:");
            foreach (var tx in Transactions)
            {
                sb.AppendLine(tx.GetTransactionData());
                sb.AppendLine(new string('-', 20));
            }
            return sb.ToString();
        }
    }
}

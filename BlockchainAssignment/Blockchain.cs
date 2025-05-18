using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;




namespace BlockchainAssignment
{
    public enum TransactionSelectionStrategy
    {
        First,
        Greedy,
        Altruistic,
        Random,
        AddressPreference
    }

    internal class Blockchain
    {
        public List<Block> blocks;
        public List<Transaction> transactionPool;
        private int transactionsPerBlock = 5;

        // Difficulty‐adjustment parameters
        private readonly int adjustmentInterval = 5;                             // every 5 blocks
        private readonly TimeSpan targetBlockInterval = TimeSpan.FromSeconds(60); // desired 60s per block
        private readonly int minDifficulty = 1;
        private readonly int maxDifficulty = 10;

        // NEW: strategy for selecting transactions
        public TransactionSelectionStrategy TxSelectionStrategy { get; set; } = TransactionSelectionStrategy.First;
        private Random rng = new Random();

        public Blockchain()
        {
            // create and mine genesis block
            blocks = new List<Block> { new Block() };
            transactionPool = new List<Transaction>();
        }

        public string GetBlockAsString(int idx)
        {
            if (idx >= 0 && idx < blocks.Count)
                return blocks[idx].GetBlockData();
            return "No such block exists";
        }

        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1];
        }

        /// <summary>
        /// Mines a new block with the pending transactions and adjusts difficulty.
        /// </summary>
        public void AddBlock(string minerAddress)
        {
            // Select and remove according to strategy
            var pending = GetPendingTransactions(minerAddress);
            var next = new Block(GetLastBlock(), pending, minerAddress);
            blocks.Add(next);

            // Adjust difficulty based on timing
            AdjustDifficulty();
        }

        /// <summary>
        /// Selects up to transactionsPerBlock from the pool per current strategy.
        /// </summary>
        private List<Transaction> GetPendingTransactions(string minerAddress)
        {
            IEnumerable<Transaction> pool = transactionPool;
            List<Transaction> selected;

            switch (TxSelectionStrategy)
            {
                case TransactionSelectionStrategy.Greedy:
                    selected = pool
                        .OrderByDescending(tx => tx.Fee)
                        .Take(transactionsPerBlock)
                        .ToList();
                    break;

                case TransactionSelectionStrategy.Altruistic:
                    selected = pool
                        .OrderBy(tx => tx.Timestamp)
                        .Take(transactionsPerBlock)
                        .ToList();
                    break;

                case TransactionSelectionStrategy.Random:
                    selected = pool
                        .OrderBy(_ => rng.Next())
                        .Take(transactionsPerBlock)
                        .ToList();
                    break;

                case TransactionSelectionStrategy.AddressPreference:
                    var preferred = pool
                        .Where(tx => tx.SenderAddress == minerAddress
                                  || tx.RecipientAddress == minerAddress);
                    var others = pool.Except(preferred);
                    selected = preferred
                        .Concat(others)
                        .Take(transactionsPerBlock)
                        .ToList();
                    break;

                case TransactionSelectionStrategy.First:
                default:
                    selected = pool
                        .Take(transactionsPerBlock)
                        .ToList();
                    break;
            }

            // remove from pool
            foreach (var tx in selected)
                transactionPool.Remove(tx);

            return selected;
        }

        /// <summary>
        /// Every adjustmentInterval blocks, scale difficulty proportionally 
        /// based on actual vs. expected mining time.
        /// </summary>
        private void AdjustDifficulty()
        {
            int count = blocks.Count;
            if (count % adjustmentInterval != 0)
                return;

            var oldBlock = blocks[count - adjustmentInterval];
            var newBlock = GetLastBlock();

            double actual = (newBlock.Timestamp - oldBlock.Timestamp).TotalSeconds;
            double expected = targetBlockInterval.TotalSeconds * adjustmentInterval;

            double ratio = expected / actual;
            int diff = (int)Math.Round(Block.Difficulty * ratio);

            // Clamp within bounds
            Block.Difficulty = Math.Max(minDifficulty, Math.Min(maxDifficulty, diff));
        }

        public string ReadAllBlocks()
        {
            var sb = new StringBuilder();
            foreach (var b in blocks)
            {
                sb.AppendLine(b.GetBlockData());
                sb.AppendLine(new string('*', 40));
            }
            return sb.ToString();
        }

        public string ReadTransactionPool()
        {
            if (transactionPool.Count == 0)
                return "Transaction pool is empty.";
            var sb = new StringBuilder();
            foreach (var tx in transactionPool)
            {
                sb.AppendLine(tx.GetTransactionData());
                sb.AppendLine(new string('-', 30));
            }
            return sb.ToString();
        }

        public string ValidateChain()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];

                // Merkle root
                string expectedMk = Block.ComputeMerkleRoot(block.Transactions);
                if (block.MerkleRoot != expectedMk)
                    return $"Invalid Merkle root at block {i}.";

                // Block hash
                string expectedBh = block.CalculateHash();
                if (block.Hash != expectedBh)
                    return $"Invalid block hash at block {i}.";

                // Transaction checks
                foreach (var tx in block.Transactions)
                {
                    string expectedTh = tx.CalculateHash();
                    if (tx.Hash != expectedTh)
                        return $"Invalid transaction hash {tx.Hash} in block {i}.";

                    bool sigOk = Wallet.Wallet.ValidateSignature(
                        tx.SenderAddress, tx.Hash, tx.Signature);
                    if (!sigOk)
                        return $"Invalid signature for tx {tx.Hash} in block {i}.";
                }

                // PreviousLink
                if (i > 0 && block.PreviousHash != blocks[i - 1].Hash)
                    return $"Invalid previous hash link at block {i}.";
            }
            return "Blockchain is valid.";
        }

        public string GetBalanceAndTransactions(string addr)
        {
            var sb = new StringBuilder();
            decimal bal = 0m;
            sb.AppendLine($"Transactions for {addr}:");
            foreach (var b in blocks)
            {
                foreach (var tx in b.Transactions)
                {
                    if (tx.SenderAddress == addr)
                    {
                        sb.AppendLine($"- Sent {tx.Amount} (+fee {tx.Fee}) to {tx.RecipientAddress} at block {b.Index}");
                        bal -= (tx.Amount + tx.Fee);
                    }
                    if (tx.RecipientAddress == addr)
                    {
                        sb.AppendLine($"- Received {tx.Amount} from {tx.SenderAddress} at block {b.Index}");
                        bal += tx.Amount;
                    }
                }
            }
            sb.AppendLine($"Current balance: {bal}");
            return sb.ToString();
        }

        public decimal GetBalance(string address)
        {
            decimal balance = 0m;
            foreach (var block in blocks)
            {
                foreach (var tx in block.Transactions)
                {
                    if (tx.RecipientAddress == address)
                        balance += tx.Amount;
                    if (tx.SenderAddress == address)
                        balance -= (tx.Amount + tx.Fee);
                }
            }
            return balance;
        }

        public override string ToString()
        {
            return ReadAllBlocks();
        }
    }
}
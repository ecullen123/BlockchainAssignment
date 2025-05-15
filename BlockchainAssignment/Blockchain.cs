using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;




namespace BlockchainAssignment
{
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

        public List<Transaction> GetPendingTransactions()
        {
            int n = Math.Min(transactionsPerBlock, transactionPool.Count);
            var txs = transactionPool.GetRange(0, n);
            transactionPool.RemoveRange(0, n);
            return txs;
        }

        /// <summary>
        /// Mines a new block with the pending transactions and adjusts difficulty.
        /// </summary>
        public void AddBlock(string minerAddress)
        {
            // Create and mine next block
            var pending = GetPendingTransactions();
            var next = new Block(GetLastBlock(), pending, minerAddress);
            blocks.Add(next);

            // Adjust difficulty based on the time it took to mine the last cycle
            AdjustDifficulty();
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

            // Block at the start of this cycle
            var oldBlock = blocks[count - adjustmentInterval];
            // Most recent block
            var newBlock = GetLastBlock();

            double actual = (newBlock.Timestamp - oldBlock.Timestamp).TotalSeconds;
            double expected = targetBlockInterval.TotalSeconds * adjustmentInterval;

            // Proportional retarget: scale difficulty by time ratio
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

                    bool sigOk = BlockchainAssignment.Wallet.Wallet.ValidateSignature(
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainAssignment.Wallet;
using BlockchainAssignment.HashCode;

namespace BlockchainAssignment.SmartContracts
{
    /// <summary>
    /// Crowdfunding campaign contract: backers pledge funds until a goal or deadline.
    /// Owner withdraws if successful; backers refund if failed.
    /// </summary>
    internal class CrowdfundingContract
    {
        public string ContractId { get; }
        public string OwnerAddress { get; }
        public decimal FundingGoal { get; }
        public DateTime Deadline { get; }
        public bool IsFinalized { get; private set; }
        public bool IsSuccessful { get; private set; }
        private Dictionary<string, decimal> _contributions = new Dictionary<string, decimal>();

        public decimal TotalRaised => _contributions.Values.Sum();

        public CrowdfundingContract(string ownerAddress, decimal fundingGoal, DateTime deadline)
        {
            OwnerAddress = ownerAddress;
            FundingGoal = fundingGoal;
            Deadline = deadline;
            ContractId = Guid.NewGuid().ToString();
            IsFinalized = false;
            IsSuccessful = false;
        }

        /// <summary>
        /// Backer pledges an amount to the campaign before deadline.
        /// </summary>
        public void Contribute(string backerAddress, decimal amount, string backerPrivateKey)
        {
            if (DateTime.Now > Deadline)
                throw new InvalidOperationException("Cannot contribute: campaign deadline has passed.");

            if (!_contributions.ContainsKey(backerAddress))
                _contributions[backerAddress] = 0m;
            _contributions[backerAddress] += amount;
        }

        /// <summary>
        /// After deadline, determine success or failure.
        /// Renamed to avoid collision with System.Object.Finalize.
        /// </summary>
        public void FinalizeCampaign()
        {
            if (IsFinalized)
                throw new InvalidOperationException("Campaign already finalized.");
            if (DateTime.Now < Deadline)
                throw new InvalidOperationException("Cannot finalize before deadline.");

            IsSuccessful = TotalRaised >= FundingGoal;
            IsFinalized = true;
        }

        /// <summary>
        /// If successful, owner withdraws all pledged funds.
        /// </summary>
        public void WithdrawFunds(string ownerPrivateKey, BlockchainAssignment.Blockchain blockchain)
        {
            if (!IsFinalized)
                throw new InvalidOperationException("Campaign not yet finalized.");
            if (!IsSuccessful)
                throw new InvalidOperationException("Cannot withdraw: campaign failed.");

            var tx = new Transaction(
                "escrow",
                OwnerAddress,
                TotalRaised,
                0m,
                ownerPrivateKey
            );
            blockchain.transactionPool.Add(tx);
            _contributions.Clear();
        }

        /// <summary>
        /// If failed, each backer can refund their own pledge.
        /// </summary>
        public void Refund(string backerAddress, string backerPrivateKey, BlockchainAssignment.Blockchain blockchain)
        {
            if (!IsFinalized)
                throw new InvalidOperationException("Campaign not yet finalized.");
            if (IsSuccessful)
                throw new InvalidOperationException("Cannot refund: campaign succeeded.");

            if (!_contributions.TryGetValue(backerAddress, out decimal amount) || amount <= 0m)
                throw new InvalidOperationException("No contributions to refund.");

            var tx = new Transaction(
                "escrow",
                backerAddress,
                amount,
                0m,
                backerPrivateKey
            );
            blockchain.transactionPool.Add(tx);
            _contributions[backerAddress] = 0m;
        }
    }
}

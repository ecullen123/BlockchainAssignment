using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;           // for StringBuilder
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        private Blockchain blockchain;

        public BlockchainApp()
        {
            InitializeComponent();

            // Initialise blockchain
            blockchain = new Blockchain();
            SetOutputText("New blockchain initialised!");

            // Configure index picker
            numericUpDownIndex.Minimum = 0;
            numericUpDownIndex.Maximum = blockchain.blocks.Count - 1;

            // Populate and default the transaction‐selection dropdown
            cmbPreference.Items.AddRange(new object[] {
                "First",
                "Greedy",
                "Altruistic",
                "Random",
                "Address Preference"
            });
            cmbPreference.SelectedIndex = 0;

            // Wire up events
            btnValidateKeys.Enabled = false;
            txtPrivateKey.TextChanged += txtPrivateKey_TextChanged;
            btnValidateChain.Click += btnValidateChain_Click;
            btnCheckBalance.Click += btnCheckBalance_Click;
            btnGenerateBlock.Click += btnGenerateBlock_Click;
        }

        private void SetOutputText(string text)
        {
            richTextBox1.Text = text;
        }

        private void btnReadAll_Click(object sender, EventArgs e)
        {
            SetOutputText(blockchain.ToString());
        }

        private void btnShowBlock_Click(object sender, EventArgs e)
        {
            SetOutputText(blockchain.GetBlockAsString((int)numericUpDownIndex.Value));
        }

        private void btnPrintPool_Click(object sender, EventArgs e)
        {
            SetOutputText(blockchain.ReadTransactionPool());
        }

        private void btnGenerateWallet_Click(object sender, EventArgs e)
        {
            string privKey;
            var wallet = new Wallet.Wallet(out privKey);
            txtPublicKey.Text = wallet.publicID;
            txtPrivateKey.Text = privKey;
        }

        private void btnValidateKeys_Click(object sender, EventArgs e)
        {
            bool ok = Wallet.Wallet.ValidatePrivateKey(
                txtPrivateKey.Text, txtPublicKey.Text);
            SetOutputText(ok ? "Keys are valid" : "Keys are invalid");
        }

        private void txtPrivateKey_TextChanged(object sender, EventArgs e)
        {
            btnValidateKeys.Enabled =
                !string.IsNullOrWhiteSpace(txtPrivateKey.Text) &&
                !string.IsNullOrWhiteSpace(txtPublicKey.Text);
        }

        private void btnSendTransaction_Click(object sender, EventArgs e)
        {
            // Trim inputs
            string senderPub = txtPublicKey.Text.Trim();
            string senderPriv = txtPrivateKey.Text.Trim();
            string recipient = txtRecipientAddress.Text.Trim();

            // Verify the private key matches the public key
            if (!Wallet.Wallet.ValidatePrivateKey(senderPriv, senderPub))
            {
                MessageBox.Show(
                    "The private key does not match the public key.",
                    "Invalid Key Pair",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Parse amount and fee
            if (!decimal.TryParse(txtAmount.Text.Trim(), out var amount) ||
                !decimal.TryParse(txtFee.Text.Trim(), out var fee))
            {
                MessageBox.Show(
                    "Please enter valid numeric values for Amount and Fee.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // All checks passed — create and queue the transaction
            try
            {
                var tx = new Transaction(
                    senderPub,
                    recipient,
                    amount,
                    fee,
                    senderPriv
                );
                blockchain.transactionPool.Add(tx);
                SetOutputText(tx.GetTransactionData());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Transaction Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGenerateBlock_Click(object sender, EventArgs e)
        {
            // 1) Update the strategy from the dropdown
            string choice = cmbPreference.SelectedItem
                .ToString()
                .Replace(" ", "");
            blockchain.TxSelectionStrategy =
                (TransactionSelectionStrategy)Enum.Parse(
                    typeof(TransactionSelectionStrategy),
                    choice
                );

            // 2) Select (and remove) according to strategy
            var minerAddr = txtPublicKey.Text.Trim();
            var pending = blockchain.GetPendingTransactions(minerAddr);

            // 3) Show the selected transactions
            var preview = new StringBuilder();
            preview.AppendLine("→ Selected transactions:");
            if (pending.Count == 0)
            {
                preview.AppendLine("   [none]");
            }
            else
            {
                foreach (var tx in pending)
                {
                    preview.AppendLine(
                        $"   Amount={tx.Amount}  Fee={tx.Fee}  From={tx.SenderAddress}"
                    );
                }
            }
            SetOutputText(preview.ToString());

            // 4) Ask user to confirm
            var result = MessageBox.Show(
                "Generate block with these transactions?",
                "Confirm Mining",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 5) Actually create & add the block
                var newBlock = new Block(
                    blockchain.GetLastBlock(),
                    pending,
                    minerAddr
                );
                blockchain.blocks.Add(newBlock);
                SetOutputText("Block mined successfully.");
            }
            else
            {
                // User cancelled: put pending back into the pool
                blockchain.transactionPool.InsertRange(0, pending);
                SetOutputText("Mining cancelled; transactions returned to pool.");
            }

            // 6) Update UI index range
            numericUpDownIndex.Maximum = blockchain.blocks.Count - 1;
        }

        private void btnValidateChain_Click(object sender, EventArgs e)
        {
            SetOutputText(blockchain.ValidateChain());
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            var addr = txtPublicKey.Text.Trim();
            if (string.IsNullOrWhiteSpace(addr))
            {
                MessageBox.Show(
                    "Generate or enter a public key first.",
                    "No Address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            SetOutputText(blockchain.GetBalanceAndTransactions(addr));
        }

        private void BlockchainApp_Load(object sender, EventArgs e) { }
    }
}
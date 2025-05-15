using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            blockchain = new Blockchain();
            SetOutputText("New blockchain initialised!");

            numericUpDownIndex.Minimum = 0;
            numericUpDownIndex.Maximum = blockchain.blocks.Count - 1;

            btnValidateKeys.Enabled = false;
            txtPrivateKey.TextChanged += txtPrivateKey_TextChanged;
            btnValidateChain.Click += btnValidateChain_Click;
            btnCheckBalance.Click += btnCheckBalance_Click;
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
            var wallet = new BlockchainAssignment.Wallet.Wallet(out privKey);
            txtPublicKey.Text = wallet.publicID;
            txtPrivateKey.Text = privKey;
        }

        private void btnValidateKeys_Click(object sender, EventArgs e)
        {
            bool ok = BlockchainAssignment.Wallet.Wallet.ValidatePrivateKey(
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
            if (!BlockchainAssignment.Wallet.Wallet.ValidatePrivateKey(senderPriv, senderPub))
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
            decimal amount;
            decimal fee;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount) ||
                !decimal.TryParse(txtFee.Text.Trim(), out fee))
            {
                MessageBox.Show(
                    "Please enter valid numeric values for Amount and Fee.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Check sufficient balance
         // decimal balance = blockchain.GetBalance(senderPub);
       //   decimal cost = amount + fee;
       //   if (balance < cost)
       //   {
         //     MessageBox.Show(
          //        $"Insufficient funds. Your balance is {balance}, but you need {cost}.",
            //      "Insufficient Funds",
            //      MessageBoxButtons.OK,
            //      MessageBoxIcon.Warning
          //    );
          //    return;
        //  }

            //All checks passed—create and queue the transaction
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
            var pending = blockchain.GetPendingTransactions();
            var nb = new Block(
                blockchain.GetLastBlock(),
                pending,
                txtPublicKey.Text.Trim());
            blockchain.blocks.Add(nb);
            numericUpDownIndex.Maximum = blockchain.blocks.Count - 1;
            SetOutputText(nb.GetBlockData());
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
                MessageBox.Show("Generate or enter a public key first.", "No Address",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetOutputText(blockchain.GetBalanceAndTransactions(addr));
        }

        private void BlockchainApp_Load(object sender, EventArgs e) { }
    }
}

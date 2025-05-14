using System.Reflection;
namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
            this.btnShowBlock = new System.Windows.Forms.Button();
            this.btnGenerateWallet = new System.Windows.Forms.Button();
            this.btnValidateKeys = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendTransaction = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtRecipientAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReadAll = new System.Windows.Forms.Button();
            this.btnGenerateBlock = new System.Windows.Forms.Button();
            this.btnPrintPool = new System.Windows.Forms.Button();
            this.btnValidateChain = new System.Windows.Forms.Button();
            this.btnCheckBalance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(657, 314);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // numericUpDownIndex
            // 
            this.numericUpDownIndex.Location = new System.Drawing.Point(93, 344);
            this.numericUpDownIndex.Name = "numericUpDownIndex";
            this.numericUpDownIndex.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownIndex.TabIndex = 1;
            // 
            // btnShowBlock
            // 
            this.btnShowBlock.Location = new System.Drawing.Point(12, 344);
            this.btnShowBlock.Name = "btnShowBlock";
            this.btnShowBlock.Size = new System.Drawing.Size(75, 23);
            this.btnShowBlock.TabIndex = 2;
            this.btnShowBlock.Text = "Print Block";
            this.btnShowBlock.UseVisualStyleBackColor = true;
            this.btnShowBlock.Click += new System.EventHandler(this.btnShowBlock_Click);
            // 
            // btnGenerateWallet
            // 
            this.btnGenerateWallet.Location = new System.Drawing.Point(594, 344);
            this.btnGenerateWallet.Name = "btnGenerateWallet";
            this.btnGenerateWallet.Size = new System.Drawing.Size(75, 38);
            this.btnGenerateWallet.TabIndex = 3;
            this.btnGenerateWallet.Text = "Generate Wallet";
            this.btnGenerateWallet.UseVisualStyleBackColor = true;
            this.btnGenerateWallet.Click += new System.EventHandler(this.btnGenerateWallet_Click);
            // 
            // btnValidateKeys
            // 
            this.btnValidateKeys.Location = new System.Drawing.Point(571, 388);
            this.btnValidateKeys.Name = "btnValidateKeys";
            this.btnValidateKeys.Size = new System.Drawing.Size(98, 21);
            this.btnValidateKeys.TabIndex = 4;
            this.btnValidateKeys.Text = "Validate Keys";
            this.btnValidateKeys.UseVisualStyleBackColor = true;
            this.btnValidateKeys.Click += new System.EventHandler(this.btnValidateKeys_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(331, 347);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(234, 20);
            this.txtPublicKey.TabIndex = 5;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(331, 373);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(234, 20);
            this.txtPrivateKey.TabIndex = 6;
            this.txtPrivateKey.TextChanged += new System.EventHandler(this.txtPrivateKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Public Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Private Key";
            // 
            // btnSendTransaction
            // 
            this.btnSendTransaction.Location = new System.Drawing.Point(21, 425);
            this.btnSendTransaction.Name = "btnSendTransaction";
            this.btnSendTransaction.Size = new System.Drawing.Size(75, 38);
            this.btnSendTransaction.TabIndex = 9;
            this.btnSendTransaction.Text = "Create Transaction";
            this.btnSendTransaction.UseVisualStyleBackColor = true;
            this.btnSendTransaction.Click += new System.EventHandler(this.btnSendTransaction_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(144, 425);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 10;
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(144, 451);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(100, 20);
            this.txtFee.TabIndex = 11;
            // 
            // txtRecipientAddress
            // 
            this.txtRecipientAddress.Location = new System.Drawing.Point(331, 435);
            this.txtRecipientAddress.Name = "txtRecipientAddress";
            this.txtRecipientAddress.Size = new System.Drawing.Size(234, 20);
            this.txtRecipientAddress.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Receiver Key";
            // 
            // btnReadAll
            // 
            this.btnReadAll.Location = new System.Drawing.Point(169, 344);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(75, 23);
            this.btnReadAll.TabIndex = 16;
            this.btnReadAll.Text = "Read All";
            this.btnReadAll.UseVisualStyleBackColor = true;
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // btnGenerateBlock
            // 
            this.btnGenerateBlock.Location = new System.Drawing.Point(21, 374);
            this.btnGenerateBlock.Name = "btnGenerateBlock";
            this.btnGenerateBlock.Size = new System.Drawing.Size(75, 45);
            this.btnGenerateBlock.TabIndex = 17;
            this.btnGenerateBlock.Text = "Generate New Block";
            this.btnGenerateBlock.UseVisualStyleBackColor = true;
            this.btnGenerateBlock.Click += new System.EventHandler(this.btnGenerateBlock_Click);
            // 
            // btnPrintPool
            // 
            this.btnPrintPool.Location = new System.Drawing.Point(116, 373);
            this.btnPrintPool.Name = "btnPrintPool";
            this.btnPrintPool.Size = new System.Drawing.Size(101, 34);
            this.btnPrintPool.TabIndex = 18;
            this.btnPrintPool.Text = "Read All pending transactions";
            this.btnPrintPool.UseVisualStyleBackColor = true;
            this.btnPrintPool.Click += new System.EventHandler(this.btnPrintPool_Click);
            // 
            // btnValidateChain
            // 
            this.btnValidateChain.Location = new System.Drawing.Point(594, 441);
            this.btnValidateChain.Name = "btnValidateChain";
            this.btnValidateChain.Size = new System.Drawing.Size(75, 50);
            this.btnValidateChain.TabIndex = 19;
            this.btnValidateChain.Text = "Full BlockChain Validation";
            this.btnValidateChain.UseVisualStyleBackColor = true;
            this.btnValidateChain.Click += new System.EventHandler(this.btnValidateChain_Click);
            // 
            // btnCheckBalance
            // 
            this.btnCheckBalance.Location = new System.Drawing.Point(476, 399);
            this.btnCheckBalance.Name = "btnCheckBalance";
            this.btnCheckBalance.Size = new System.Drawing.Size(89, 30);
            this.btnCheckBalance.TabIndex = 20;
            this.btnCheckBalance.Text = "Check Balance";
            this.btnCheckBalance.UseVisualStyleBackColor = true;
            this.btnCheckBalance.Click += new System.EventHandler(this.btnCheckBalance_Click);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(681, 481);
            this.Controls.Add(this.btnCheckBalance);
            this.Controls.Add(this.btnValidateChain);
            this.Controls.Add(this.btnPrintPool);
            this.Controls.Add(this.btnGenerateBlock);
            this.Controls.Add(this.btnReadAll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRecipientAddress);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSendTransaction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.btnValidateKeys);
            this.Controls.Add(this.btnGenerateWallet);
            this.Controls.Add(this.btnShowBlock);
            this.Controls.Add(this.numericUpDownIndex);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.BlockchainApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownIndex;
        private System.Windows.Forms.Button btnShowBlock;
        private System.Windows.Forms.Button btnGenerateWallet;
        private System.Windows.Forms.Button btnValidateKeys;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSendTransaction;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.TextBox txtRecipientAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReadAll;
        private System.Windows.Forms.Button btnGenerateBlock;
        private System.Windows.Forms.Button btnPrintPool;
        private System.Windows.Forms.Button btnValidateChain;
        private System.Windows.Forms.Button btnCheckBalance;
    }
}


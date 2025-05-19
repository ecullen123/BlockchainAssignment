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
            this.cmbPreference = new System.Windows.Forms.ComboBox();
            this.btnCreateCampaign = new System.Windows.Forms.Button();
            this.txtOwnerAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numGoalAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnContribute = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.lstCampaigns = new System.Windows.Forms.ListBox();
            this.txtBackerAddress = new System.Windows.Forms.TextBox();
            this.numPledgeAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.txtOwnerPrivKey = new System.Windows.Forms.TextBox();
            this.txtBackerPrivKey = new System.Windows.Forms.TextBox();
            this.lblTotalRaised = new System.Windows.Forms.Label();
            this.lblIsFinalized = new System.Windows.Forms.Label();
            this.lblIsSuccessful = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGoalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPledgeAmount)).BeginInit();
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
            this.btnValidateChain.Location = new System.Drawing.Point(594, 415);
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
            // cmbPreference
            // 
            this.cmbPreference.FormattingEnabled = true;
            this.cmbPreference.Location = new System.Drawing.Point(236, 398);
            this.cmbPreference.Name = "cmbPreference";
            this.cmbPreference.Size = new System.Drawing.Size(121, 21);
            this.cmbPreference.TabIndex = 21;
            // 
            // btnCreateCampaign
            // 
            this.btnCreateCampaign.Location = new System.Drawing.Point(105, 602);
            this.btnCreateCampaign.Name = "btnCreateCampaign";
            this.btnCreateCampaign.Size = new System.Drawing.Size(75, 39);
            this.btnCreateCampaign.TabIndex = 22;
            this.btnCreateCampaign.Text = "Create Campaign";
            this.btnCreateCampaign.UseVisualStyleBackColor = true;
            this.btnCreateCampaign.Click += new System.EventHandler(this.btnCreateCampaign_Click);
            // 
            // txtOwnerAddress
            // 
            this.txtOwnerAddress.Location = new System.Drawing.Point(105, 503);
            this.txtOwnerAddress.Name = "txtOwnerAddress";
            this.txtOwnerAddress.Size = new System.Drawing.Size(100, 20);
            this.txtOwnerAddress.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Owner Public Key";
            // 
            // numGoalAmount
            // 
            this.numGoalAmount.Location = new System.Drawing.Point(105, 550);
            this.numGoalAmount.Name = "numGoalAmount";
            this.numGoalAmount.Size = new System.Drawing.Size(120, 20);
            this.numGoalAmount.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 552);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Goal Amount";
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Location = new System.Drawing.Point(105, 576);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(135, 20);
            this.dtpDeadline.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 582);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Date Deadline";
            // 
            // btnContribute
            // 
            this.btnContribute.Location = new System.Drawing.Point(530, 557);
            this.btnContribute.Name = "btnContribute";
            this.btnContribute.Size = new System.Drawing.Size(75, 39);
            this.btnContribute.TabIndex = 29;
            this.btnContribute.Text = "Contribute";
            this.btnContribute.UseVisualStyleBackColor = true;
            this.btnContribute.Click += new System.EventHandler(this.btnContribute_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(530, 599);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(75, 23);
            this.btnWithdraw.TabIndex = 30;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(530, 623);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(75, 23);
            this.btnRefund.TabIndex = 31;
            this.btnRefund.Text = "Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // lstCampaigns
            // 
            this.lstCampaigns.FormattingEnabled = true;
            this.lstCampaigns.Location = new System.Drawing.Point(530, 500);
            this.lstCampaigns.Name = "lstCampaigns";
            this.lstCampaigns.Size = new System.Drawing.Size(139, 56);
            this.lstCampaigns.TabIndex = 32;
            // 
            // txtBackerAddress
            // 
            this.txtBackerAddress.Location = new System.Drawing.Point(424, 500);
            this.txtBackerAddress.Name = "txtBackerAddress";
            this.txtBackerAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBackerAddress.TabIndex = 33;
            // 
            // numPledgeAmount
            // 
            this.numPledgeAmount.Location = new System.Drawing.Point(424, 557);
            this.numPledgeAmount.Name = "numPledgeAmount";
            this.numPledgeAmount.Size = new System.Drawing.Size(87, 20);
            this.numPledgeAmount.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 503);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Backer Public Key";
            // 
            // btnFinalize
            // 
            this.btnFinalize.Location = new System.Drawing.Point(186, 615);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(75, 23);
            this.btnFinalize.TabIndex = 36;
            this.btnFinalize.Text = "Finalize";
            this.btnFinalize.UseVisualStyleBackColor = true;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // txtOwnerPrivKey
            // 
            this.txtOwnerPrivKey.Location = new System.Drawing.Point(105, 522);
            this.txtOwnerPrivKey.Name = "txtOwnerPrivKey";
            this.txtOwnerPrivKey.Size = new System.Drawing.Size(100, 20);
            this.txtOwnerPrivKey.TabIndex = 37;
            // 
            // txtBackerPrivKey
            // 
            this.txtBackerPrivKey.Location = new System.Drawing.Point(424, 526);
            this.txtBackerPrivKey.Name = "txtBackerPrivKey";
            this.txtBackerPrivKey.Size = new System.Drawing.Size(100, 20);
            this.txtBackerPrivKey.TabIndex = 38;
            // 
            // lblTotalRaised
            // 
            this.lblTotalRaised.AutoSize = true;
            this.lblTotalRaised.Location = new System.Drawing.Point(264, 599);
            this.lblTotalRaised.Name = "lblTotalRaised";
            this.lblTotalRaised.Size = new System.Drawing.Size(70, 13);
            this.lblTotalRaised.TabIndex = 39;
            this.lblTotalRaised.Text = "Total Raised:";
            // 
            // lblIsFinalized
            // 
            this.lblIsFinalized.AutoSize = true;
            this.lblIsFinalized.Location = new System.Drawing.Point(267, 615);
            this.lblIsFinalized.Name = "lblIsFinalized";
            this.lblIsFinalized.Size = new System.Drawing.Size(51, 13);
            this.lblIsFinalized.TabIndex = 40;
            this.lblIsFinalized.Text = "Finalised:";
            // 
            // lblIsSuccessful
            // 
            this.lblIsSuccessful.AutoSize = true;
            this.lblIsSuccessful.Location = new System.Drawing.Point(264, 628);
            this.lblIsSuccessful.Name = "lblIsSuccessful";
            this.lblIsSuccessful.Size = new System.Drawing.Size(62, 13);
            this.lblIsSuccessful.TabIndex = 41;
            this.lblIsSuccessful.Text = "Successful:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 526);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Owner Private Key";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 529);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Backer Private Key";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(556, 484);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Campaigns List";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(364, 564);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Amount";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 651);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(19, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 2);
            this.panel1.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(285, 476);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "CrowdFunder";
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(681, 651);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblIsSuccessful);
            this.Controls.Add(this.lblIsFinalized);
            this.Controls.Add(this.lblTotalRaised);
            this.Controls.Add(this.txtBackerPrivKey);
            this.Controls.Add(this.txtOwnerPrivKey);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numPledgeAmount);
            this.Controls.Add(this.txtBackerAddress);
            this.Controls.Add(this.lstCampaigns);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnContribute);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numGoalAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOwnerAddress);
            this.Controls.Add(this.btnCreateCampaign);
            this.Controls.Add(this.cmbPreference);
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
            ((System.ComponentModel.ISupportInitialize)(this.numGoalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPledgeAmount)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbPreference;
        private System.Windows.Forms.Button btnCreateCampaign;
        private System.Windows.Forms.TextBox txtOwnerAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numGoalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnContribute;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.ListBox lstCampaigns;
        private System.Windows.Forms.TextBox txtBackerAddress;
        private System.Windows.Forms.NumericUpDown numPledgeAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.TextBox txtOwnerPrivKey;
        private System.Windows.Forms.TextBox txtBackerPrivKey;
        private System.Windows.Forms.Label lblTotalRaised;
        private System.Windows.Forms.Label lblIsFinalized;
        private System.Windows.Forms.Label lblIsSuccessful;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
    }
}


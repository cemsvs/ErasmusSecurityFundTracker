namespace ErasmusBudgetTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTargetTitle = new Label();
            lblBalanceTitle = new Label();
            lblCurrentBalance = new Label();
            groupBox1 = new GroupBox();
            btnAddTransaction = new Button();
            numAmount = new NumericUpDown();
            txtDescription = new TextBox();
            lstTransactions = new ListBox();
            btnSave = new Button();
            btnLoad = new Button();
            numTargetGoal = new NumericUpDown();
            btnUpdateGoal = new Button();
            lblTryEquivalent = new Label();
            lblLiveRate = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetGoal).BeginInit();
            SuspendLayout();
            // 
            // lblTargetTitle
            // 
            lblTargetTitle.AutoSize = true;
            lblTargetTitle.Font = new Font("Segoe UI", 12F);
            lblTargetTitle.Location = new Point(12, 9);
            lblTargetTitle.Name = "lblTargetTitle";
            lblTargetTitle.Size = new Size(178, 28);
            lblTargetTitle.TabIndex = 0;
            lblTargetTitle.Text = "Target Safety Fund:";
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Font = new Font("Segoe UI", 12F);
            lblBalanceTitle.Location = new Point(74, 46);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(116, 28);
            lblBalanceTitle.TabIndex = 2;
            lblBalanceTitle.Text = "Total Saved:";
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Font = new Font("Segoe UI", 12F);
            lblCurrentBalance.Location = new Point(196, 47);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(34, 28);
            lblCurrentBalance.TabIndex = 3;
            lblCurrentBalance.Text = "0€";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddTransaction);
            groupBox1.Controls.Add(numAmount);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Location = new Point(12, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(530, 137);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Expense/Income";
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Location = new Point(415, 61);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(109, 29);
            btnAddTransaction.TabIndex = 2;
            btnAddTransaction.Text = "Add";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // numAmount
            // 
            numAmount.DecimalPlaces = 2;
            numAmount.Location = new Point(259, 61);
            numAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numAmount.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(150, 27);
            numAmount.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(6, 61);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(247, 27);
            txtDescription.TabIndex = 0;
            // 
            // lstTransactions
            // 
            lstTransactions.AccessibleName = "";
            lstTransactions.FormattingEnabled = true;
            lstTransactions.Location = new Point(12, 235);
            lstTransactions.Name = "lstTransactions";
            lstTransactions.Size = new Size(530, 204);
            lstTransactions.TabIndex = 5;
            lstTransactions.Tag = "";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(568, 284);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(568, 350);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // numTargetGoal
            // 
            numTargetGoal.Font = new Font("Segoe UI", 12F);
            numTargetGoal.Location = new Point(196, 7);
            numTargetGoal.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numTargetGoal.Name = "numTargetGoal";
            numTargetGoal.Size = new Size(162, 34);
            numTargetGoal.TabIndex = 8;
            numTargetGoal.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // btnUpdateGoal
            // 
            btnUpdateGoal.Location = new Point(364, 7);
            btnUpdateGoal.Name = "btnUpdateGoal";
            btnUpdateGoal.Size = new Size(94, 34);
            btnUpdateGoal.TabIndex = 9;
            btnUpdateGoal.Text = "Set";
            btnUpdateGoal.UseVisualStyleBackColor = true;
            btnUpdateGoal.Click += btnUpdateGoal_Click;
            // 
            // lblTryEquivalent
            // 
            lblTryEquivalent.AutoSize = true;
            lblTryEquivalent.ForeColor = SystemColors.ControlDarkDark;
            lblTryEquivalent.Location = new Point(336, 53);
            lblTryEquivalent.Name = "lblTryEquivalent";
            lblTryEquivalent.Size = new Size(122, 20);
            lblTryEquivalent.TabIndex = 10;
            lblTryEquivalent.Text = "(Checking Rate...)";
            // 
            // lblLiveRate
            // 
            lblLiveRate.AutoSize = true;
            lblLiveRate.ForeColor = SystemColors.ControlDarkDark;
            lblLiveRate.Location = new Point(569, 9);
            lblLiveRate.Name = "lblLiveRate";
            lblLiveRate.Size = new Size(52, 20);
            lblLiveRate.TabIndex = 11;
            lblLiveRate.Text = "Rate: -";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 450);
            Controls.Add(lblLiveRate);
            Controls.Add(lblTryEquivalent);
            Controls.Add(btnUpdateGoal);
            Controls.Add(numTargetGoal);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(lstTransactions);
            Controls.Add(groupBox1);
            Controls.Add(lblCurrentBalance);
            Controls.Add(lblBalanceTitle);
            Controls.Add(lblTargetTitle);
            Name = "Form1";
            Text = "Erasmus Security Fund Tracker";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetGoal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTargetTitle;
        private Label lblBalanceTitle;
        private Label lblCurrentBalance;
        private GroupBox groupBox1;
        private Button btnAddTransaction;
        private NumericUpDown numAmount;
        private TextBox txtDescription;
        private ListBox lstTransactions;
        private Button btnSave;
        private Button btnLoad;
        private NumericUpDown numTargetGoal;
        private Button btnUpdateGoal;
        private Label lblTryEquivalent;
        private Label lblLiveRate;
    }
}

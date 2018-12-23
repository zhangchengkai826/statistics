namespace Statistics
{
    partial class DataAnalyzerWizard
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
            this.components = new System.ComponentModel.Container();
            this.tbStatNeedsAnalyze = new System.Windows.Forms.ListBox();
            this.btStart = new System.Windows.Forms.Button();
            this.cbSrc2 = new System.Windows.Forms.ComboBox();
            this.lblSrc2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSrc1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStatType = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbStatNeedsAnalyze
            // 
            this.tbStatNeedsAnalyze.FormattingEnabled = true;
            this.tbStatNeedsAnalyze.ItemHeight = 12;
            this.tbStatNeedsAnalyze.Location = new System.Drawing.Point(12, 12);
            this.tbStatNeedsAnalyze.Name = "tbStatNeedsAnalyze";
            this.tbStatNeedsAnalyze.Size = new System.Drawing.Size(616, 244);
            this.tbStatNeedsAnalyze.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btStart.Location = new System.Drawing.Point(13, 400);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(167, 38);
            this.btStart.TabIndex = 5;
            this.btStart.Text = "Start Analyze";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cbSrc2
            // 
            this.cbSrc2.FormattingEnabled = true;
            this.cbSrc2.Location = new System.Drawing.Point(654, 142);
            this.cbSrc2.Name = "cbSrc2";
            this.cbSrc2.Size = new System.Drawing.Size(121, 20);
            this.cbSrc2.TabIndex = 7;
            // 
            // lblSrc2
            // 
            this.lblSrc2.AutoSize = true;
            this.lblSrc2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSrc2.Location = new System.Drawing.Point(649, 114);
            this.lblSrc2.Name = "lblSrc2";
            this.lblSrc2.Size = new System.Drawing.Size(149, 25);
            this.lblSrc2.TabIndex = 8;
            this.lblSrc2.Text = "Source Column 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(649, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Source Column 1";
            // 
            // cbSrc1
            // 
            this.cbSrc1.FormattingEnabled = true;
            this.cbSrc1.Location = new System.Drawing.Point(654, 91);
            this.cbSrc1.Name = "cbSrc1";
            this.cbSrc1.Size = new System.Drawing.Size(121, 20);
            this.cbSrc1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(649, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Statistic Type";
            // 
            // cbStatType
            // 
            this.cbStatType.FormattingEnabled = true;
            this.cbStatType.Location = new System.Drawing.Point(654, 40);
            this.cbStatType.Name = "cbStatType";
            this.cbStatType.Size = new System.Drawing.Size(121, 20);
            this.cbStatType.TabIndex = 11;
            this.cbStatType.SelectionChangeCommitted += new System.EventHandler(this.cbStatType_SelectionChangeCommitted);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAdd.Location = new System.Drawing.Point(654, 168);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(121, 38);
            this.btAdd.TabIndex = 14;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRemove.Location = new System.Drawing.Point(654, 212);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(121, 38);
            this.btRemove.TabIndex = 15;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSave.Location = new System.Drawing.Point(186, 400);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(121, 38);
            this.btSave.TabIndex = 16;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgress.Location = new System.Drawing.Point(313, 407);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(462, 25);
            this.lblProgress.TabIndex = 17;
            this.lblProgress.Text = "0 stats analyzed / 0 remained";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbReport
            // 
            this.tbReport.Location = new System.Drawing.Point(13, 262);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbReport.Size = new System.Drawing.Size(762, 132);
            this.tbReport.TabIndex = 18;
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 1000;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // DataAnalyzerWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStatType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSrc1);
            this.Controls.Add(this.lblSrc2);
            this.Controls.Add(this.cbSrc2);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbStatNeedsAnalyze);
            this.Name = "DataAnalyzerWizard";
            this.Text = "Data Analyze Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox tbStatNeedsAnalyze;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ComboBox cbSrc2;
        private System.Windows.Forms.Label lblSrc2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSrc1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStatType;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Timer progressTimer;
    }
}
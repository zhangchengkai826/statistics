namespace Statistics
{
    partial class DetermineTypeForm
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
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.lblTblName = new System.Windows.Forms.Label();
            this.btImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTblName = new System.Windows.Forms.TextBox();
            this.progressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGrid
            // 
            this.MainGrid.AllowUserToAddRows = false;
            this.MainGrid.AllowUserToDeleteRows = false;
            this.MainGrid.AllowUserToResizeRows = false;
            this.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGrid.Location = new System.Drawing.Point(12, 37);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.RowTemplate.Height = 23;
            this.MainGrid.Size = new System.Drawing.Size(776, 365);
            this.MainGrid.TabIndex = 0;
            // 
            // lblTblName
            // 
            this.lblTblName.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTblName.Location = new System.Drawing.Point(12, 9);
            this.lblTblName.Name = "lblTblName";
            this.lblTblName.Size = new System.Drawing.Size(776, 25);
            this.lblTblName.TabIndex = 4;
            this.lblTblName.Text = "Please determine the type of each column";
            this.lblTblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btImport
            // 
            this.btImport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btImport.Location = new System.Drawing.Point(352, 408);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(104, 38);
            this.btImport.TabIndex = 5;
            this.btImport.Text = "Import!";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Table Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTblName
            // 
            this.tbTblName.Location = new System.Drawing.Point(139, 418);
            this.tbTblName.Name = "tbTblName";
            this.tbTblName.Size = new System.Drawing.Size(188, 21);
            this.tbTblName.TabIndex = 7;
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Enabled = true;
            this.progressBarTimer.Interval = 1000;
            this.progressBarTimer.Tick += new System.EventHandler(this.progressBarTimer_Tick);
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgress.Location = new System.Drawing.Point(462, 415);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(326, 25);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "0 insert / 0 discover";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DetermineTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.tbTblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.lblTblName);
            this.Controls.Add(this.MainGrid);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "DetermineTypeForm";
            this.Text = "Import Table Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.Label lblTblName;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTblName;
        private System.Windows.Forms.Timer progressBarTimer;
        private System.Windows.Forms.Label lblProgress;
    }
}
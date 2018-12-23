namespace Statistics
{
    partial class ExportTableWizard
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
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgress.Location = new System.Drawing.Point(12, 9);
            this.lblProgress.MaximumSize = new System.Drawing.Size(464, 46);
            this.lblProgress.MinimumSize = new System.Drawing.Size(464, 46);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(464, 46);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "0 page(s) exported / 0 page(s) in total";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressTimer
            // 
            this.progressTimer.Enabled = true;
            this.progressTimer.Interval = 1000;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // ExportTableWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 64);
            this.Controls.Add(this.lblProgress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportTableWizard";
            this.Text = "Export Table Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportTableWizard_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Timer progressTimer;
    }
}
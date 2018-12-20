namespace Statistics
{
    partial class CreateTblForm
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
            this.lblTblName = new System.Windows.Forms.Label();
            this.tbTblName = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblColName = new System.Windows.Forms.Label();
            this.lblColType = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTblName
            // 
            this.lblTblName.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTblName.Location = new System.Drawing.Point(92, 9);
            this.lblTblName.Name = "lblTblName";
            this.lblTblName.Size = new System.Drawing.Size(106, 25);
            this.lblTblName.TabIndex = 3;
            this.lblTblName.Text = "Table Name";
            this.lblTblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTblName
            // 
            this.tbTblName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTblName.Location = new System.Drawing.Point(222, 13);
            this.tbTblName.Name = "tbTblName";
            this.tbTblName.Size = new System.Drawing.Size(188, 22);
            this.tbTblName.TabIndex = 2;
            // 
            // btCreate
            // 
            this.btCreate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCreate.Location = new System.Drawing.Point(267, 611);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(143, 38);
            this.btCreate.TabIndex = 12;
            this.btCreate.Text = "Create!";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.lblColName);
            this.MainPanel.Controls.Add(this.lblColType);
            this.MainPanel.Location = new System.Drawing.Point(12, 40);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(460, 565);
            this.MainPanel.TabIndex = 13;
            // 
            // lblColName
            // 
            this.lblColName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblColName.Location = new System.Drawing.Point(3, 0);
            this.lblColName.Name = "lblColName";
            this.lblColName.Size = new System.Drawing.Size(220, 23);
            this.lblColName.TabIndex = 0;
            this.lblColName.Text = "Column Name";
            this.lblColName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColType
            // 
            this.lblColType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblColType.Location = new System.Drawing.Point(229, 0);
            this.lblColType.Name = "lblColType";
            this.lblColType.Size = new System.Drawing.Size(220, 23);
            this.lblColType.TabIndex = 1;
            this.lblColType.Text = "Column Type";
            this.lblColType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAdd.Location = new System.Drawing.Point(65, 611);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(143, 38);
            this.btAdd.TabIndex = 14;
            this.btAdd.Text = "Add Column";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // CreateTblForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.lblTblName);
            this.Controls.Add(this.tbTblName);
            this.MaximumSize = new System.Drawing.Size(500, 700);
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "CreateTblForm";
            this.Text = "Create Table";
            this.Load += new System.EventHandler(this.CreateTblForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTblName;
        private System.Windows.Forms.TextBox tbTblName;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lblColName;
        private System.Windows.Forms.Label lblColType;
    }
}
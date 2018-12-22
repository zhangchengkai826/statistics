namespace Statistics
{
    partial class InsertForm
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
            this.InsertData = new System.Windows.Forms.DataGridView();
            this.btInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InsertData)).BeginInit();
            this.SuspendLayout();
            // 
            // InsertData
            // 
            this.InsertData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InsertData.Location = new System.Drawing.Point(12, 12);
            this.InsertData.Name = "InsertData";
            this.InsertData.RowTemplate.Height = 23;
            this.InsertData.Size = new System.Drawing.Size(776, 388);
            this.InsertData.TabIndex = 0;
            this.InsertData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.InsertData_DataError);
            // 
            // btInsert
            // 
            this.btInsert.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btInsert.Location = new System.Drawing.Point(349, 406);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(104, 38);
            this.btInsert.TabIndex = 11;
            this.btInsert.Text = "Insert!";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btInsert);
            this.Controls.Add(this.InsertData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertForm";
            this.Text = "Insert Row";
            ((System.ComponentModel.ISupportInitialize)(this.InsertData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView InsertData;
        private System.Windows.Forms.Button btInsert;
    }
}
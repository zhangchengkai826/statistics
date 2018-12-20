namespace Statistics
{
    partial class StartNewConnForm
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
            this.btConn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsrName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btConn
            // 
            this.btConn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btConn.Location = new System.Drawing.Point(186, 293);
            this.btConn.Name = "btConn";
            this.btConn.Size = new System.Drawing.Size(104, 38);
            this.btConn.TabIndex = 9;
            this.btConn.Text = "Connect!";
            this.btConn.UseVisualStyleBackColor = true;
            this.btConn.Click += new System.EventHandler(this.btConn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(83, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // tbPw
            // 
            this.tbPw.Location = new System.Drawing.Point(213, 204);
            this.tbPw.Name = "tbPw";
            this.tbPw.PasswordChar = '*';
            this.tbPw.Size = new System.Drawing.Size(188, 21);
            this.tbPw.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(83, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Name";
            // 
            // tbUsrName
            // 
            this.tbUsrName.Location = new System.Drawing.Point(213, 134);
            this.tbUsrName.Name = "tbUsrName";
            this.tbUsrName.Size = new System.Drawing.Size(188, 21);
            this.tbUsrName.TabIndex = 5;
            // 
            // StartNewConnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btConn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUsrName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "StartNewConnForm";
            this.Text = "Start New Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsrName;
    }
}
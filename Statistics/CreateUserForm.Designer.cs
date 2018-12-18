namespace Statistics
{
    partial class CreateUserForm
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
            this.tbUsrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUsrName
            // 
            this.tbUsrName.Location = new System.Drawing.Point(214, 119);
            this.tbUsrName.Name = "tbUsrName";
            this.tbUsrName.Size = new System.Drawing.Size(188, 21);
            this.tbUsrName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(84, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(84, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // tbPw
            // 
            this.tbPw.Location = new System.Drawing.Point(214, 189);
            this.tbPw.Name = "tbPw";
            this.tbPw.PasswordChar = '*';
            this.tbPw.Size = new System.Drawing.Size(188, 21);
            this.tbPw.TabIndex = 2;
            // 
            // btCreate
            // 
            this.btCreate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCreate.Location = new System.Drawing.Point(187, 278);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(104, 38);
            this.btCreate.TabIndex = 4;
            this.btCreate.Text = "Create!";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUsrName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "CreateUserForm";
            this.Text = "Create User";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPw;
        private System.Windows.Forms.Button btCreate;
    }
}